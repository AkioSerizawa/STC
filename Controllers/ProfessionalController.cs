using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Application;
using STC.DTOs.Professional;
using STC.Extensions;
using STC.Models;
using STC.Utils;
using STC.View;
using STC.View.ProfessionalViewModel;

namespace STC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessionalController : ControllerBase
    {
        #region Properties

        private ProfessionalApplication professionalApplication = new ProfessionalApplication();

        #endregion Properties

        #region Methods

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<ProfessionalViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<ProfessionalViewModel>>> CreateProfessional(
            [FromBody] CreateProfessionalDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var professionalViewModel = await professionalApplication.CreateProfessionalAsync(model);
                return Ok(new ResultViewModel<ProfessionalViewModel>(professionalViewModel));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400, new ResultViewModel<Professional>(UtilMessages.professional04XE02(ex)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Professional>(UtilMessages.professional04XE01(ex)));
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<List<ProfessionalViewModel>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultViewModel<ProfessionalViewModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<List<ProfessionalViewModel>>>> GetAllProfessionals()
        {
            List<ProfessionalViewModel> professionals = await professionalApplication.GetAllProfessionalsAsync();
            if (professionals.Count == 0)
                return NotFound(new ResultViewModel<ProfessionalViewModel>(UtilMessages.professional04XE03()));

            return Ok(new ResultViewModel<List<ProfessionalViewModel>>(professionals));
        }

        [HttpGet("{profId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<ProfessionalViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultViewModel<ProfessionalViewModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<ProfessionalViewModel>>> GetProfessionalById(
            [FromRoute] int profId
        )
        {
            try
            {
                var professional = await professionalApplication.GetProfessionalByIdAsync(profId);
                if (professional == null)
                    return NotFound(new ResultViewModel<ProfessionalViewModel>(UtilMessages.professional04XE03()));

                return Ok(new ResultViewModel<ProfessionalViewModel>(professional));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Professional>(UtilMessages.professional04XE01(ex)));
            }
        }

        #endregion Methods
    }
}