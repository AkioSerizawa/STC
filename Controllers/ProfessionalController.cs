using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Application;
using STC.DTOs.Professional;
using STC.Extensions;
using STC.Models;
using STC.Services;
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
        private ProfessionalService professionalService = new ProfessionalService();
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public ProfessionalController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<CreateProfessionalViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<CreateProfessionalViewModel>>> CreateProfessional(
            [FromBody] CreateProfessionalDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var professional = await professionalApplication.CreateProfessionalAsync(model);
                var professionalViewModel = _mapper.Map<CreateProfessionalViewModel>(professional);

                return Ok(new ResultViewModel<CreateProfessionalViewModel>(professionalViewModel));
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<List<Professional>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultViewModel<Professional>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<List<Professional>>>> GetAllProfessionals()
        {
            List<Professional> professionals = await professionalApplication.GetAllProfessionalsAsync();
            if (professionals.Count == 0)
                return NotFound(new ResultViewModel<Professional>(UtilMessages.professional04XE03()));

            return Ok(new ResultViewModel<List<Professional>>(professionals));
        }

        [HttpGet("{profId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<Professional>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultViewModel<Professional>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<Professional>>> GetProfessionalById(
            [FromRoute] int profId
        )
        {
            try
            {
                Professional professional = await professionalApplication.GetProfessionalByIdAsync(profId);
                if (professional == null)
                    return NotFound(new ResultViewModel<Professional>(UtilMessages.professional04XE03()));

                return Ok(new ResultViewModel<Professional>(professional));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Professional>(UtilMessages.professional04XE01(ex)));
            }
        }

        [HttpGet("{profName")]
        public async Task<ActionResult> GetProfessionalByName(
            [FromRoute] string profName
        )
        {
            // Professional professional = 

            return Ok();
        }

        #endregion Methods
    }
}