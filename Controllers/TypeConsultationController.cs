using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Application;
using STC.DTOs.TypeConsultation;
using STC.Extensions;
using STC.Models;
using STC.Utils;
using STC.View;

namespace STC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TypeConsultationController : ControllerBase
    {
        #region Properties

        private TypeConsultationApplication typeConsultationApplication = new TypeConsultationApplication();

        #endregion Properties

        #region Methods

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<TypeConsultation>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<TypeConsultation>>> CreateTypeConsultationAsync(
            [FromBody] CreateTypeConsultationDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var typeConsultation = await typeConsultationApplication.CreateTypeConsultation(model);
                return Ok(new ResultViewModel<TypeConsultation>(typeConsultation));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400, new ResultViewModel<TypeConsultation>(UtilMessages.typeConsultation05XE02(ex)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<TypeConsultation>(UtilMessages.typeConsultation05XE01(ex)));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeConsultationsAsync()
        {
            try
            {
                var typeConsultations = await typeConsultationApplication.GetTypeConsultations();

                if (typeConsultations.Count == 0)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                return Ok(typeConsultations);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{typeId}")]
        public async Task<ActionResult<ResultViewModel<TypeConsultation>>> GetTypeConsultationById(
            [FromRoute] int typeId
        )
        {
            var type = await typeConsultationApplication.GetTypeById(typeId);
            var result = new ResultViewModel<TypeConsultation>(type);
            return Ok(result);
        }
    }

    #endregion Methods
}