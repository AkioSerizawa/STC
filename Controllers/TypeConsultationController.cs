using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Application;
using STC.DTOs.TypeConsultation;
using STC.Extensions;
using STC.Models;
using STC.Utils;
using STC.View;
using STC.View.TypeConsultationViewModel;

namespace STC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TypeConsultationController : ControllerBase
    {
        #region Properties

        private TypeConsultationApplication typeConsultationApplication = new TypeConsultationApplication();
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public TypeConsultationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<CreateTypeConsultationViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<CreateTypeConsultationViewModel>>> CreateTypeConsultationAsync(
            [FromBody] CreateTypeConsultationDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var typeConsultation = await typeConsultationApplication.CreateTypeConsultationAsync(model);
                var typeConsultationViewModel = _mapper.Map<CreateTypeConsultationViewModel>(typeConsultation);

                return Ok(new ResultViewModel<CreateTypeConsultationViewModel>(typeConsultationViewModel));
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<List<TypeConsultation>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultViewModel<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<List<TypeConsultation>>>> GetTypeConsultationsAsync()
        {
            var typeConsultations = await typeConsultationApplication.GetTypeConsultationsAsync();
            if (typeConsultations.Count == 0)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var result = new ResultViewModel<List<TypeConsultation>>(typeConsultations);
            return Ok(result);
        }

        [HttpGet("{typeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<TypeConsultation>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultViewModel<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<TypeConsultation>>> GetTypeConsultationById(
            [FromRoute] int typeId
        )
        {
            var type = await typeConsultationApplication.GetTypeById(typeId);
            if (type == null)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var result = new ResultViewModel<TypeConsultation>(type);
            return Ok(result);
        }
    }

    #endregion Methods
}