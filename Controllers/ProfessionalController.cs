using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Application;
using STC.Extensions;
using STC.Models;
using STC.Services;
using STC.Utils;
using STC.View;
using STC.View.ProfessionalViewModel;

namespace STC.Controllers
{
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private ProfessionalApplication professionalApplication = new ProfessionalApplication();
        private ProfessionalService professionalService = new ProfessionalService();

        [HttpPost("v1/professional")]
        public async Task<IActionResult> CreateProfessionalAsync(
            [FromBody] CreateProfessionalViewModel model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var professional = await professionalApplication.CreateProfessionalAsync(model);
                string professionalFormatted = $"Professional cadastro com sucesso - Id: {professional.ProfId} | Nome: {professional.ProfName} | Profissão: {professional.ProfJob} | Habilitado para consultas: {professional.ProfConsultation} | Profissional Ativo: {professional.ProfActive}";

                return Ok(new ResultViewModel<dynamic>(professionalFormatted, null));
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

        [HttpGet("v1/professional")]
        public async Task<IActionResult> GetProfessionals()
        {
            try
            {
                List<Professional> professionals = await professionalService.GetProfessionals();
                if (professionals.Count == 0)
                    return NotFound(new ResultViewModel<Professional>(UtilMessages.professional04XE03()));

                return Ok(new ResultViewModel<List<Professional>>(professionals));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("v1/professional/{profId:int}")]
        public async Task<IActionResult> GetProfessionalById(
            [FromRoute] int profId
        )
        {
            try
            {
                Professional professional = await professionalService.GetProfessionalById(profId);
                if (professional == null)
                    return NotFound(new ResultViewModel<Client>(UtilMessages.professional04XE03()));

                return Ok(new ResultViewModel<Professional>(professional));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Professional>(UtilMessages.professional04XE01(ex)));
            }
        }
    }
}