using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Application;
using STC.DTOs.ClientDto;
using STC.Extensions;
using STC.Models;
using STC.Services;
using STC.Utils;
using STC.View;
using STC.View.ClientViewModel;

namespace STC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        #region Properties

        private ClientApplication clientApplication = new ClientApplication();
        private ClientService clientService = new ClientService();

        #endregion Properties

        #region Methods

        [HttpPost]
        public async Task<ActionResult<ResultViewModel<dynamic>>> CreateClientAsync(
            [FromBody] CreateClientDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var client = await clientApplication.CreateClient(model);
                string clientFormatted =
                    $"Cliente criado com sucesso - Id: {client.CliId} | Nome do Cliente: {client.CliName}";

                return Ok(new ResultViewModel<dynamic>(clientFormatted, null));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400, new ResultViewModel<Client>(UtilMessages.client03XE02(ex)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Client>(UtilMessages.client03XE01(ex)));
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResultViewModel<List<ClientViewModel>>>> GetClientsAsync()
        {
            try
            {
                var clients = await clientApplication.GetAllClientAsync();
                if (clients.Count == 0)
                    return NotFound(new ResultViewModel<Client>(UtilMessages.client03XE03()));

                return Ok(new ResultViewModel<List<ClientViewModel>>(clients));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Client>(UtilMessages.client03XE01(ex)));
            }
        }

        [HttpGet("{cliId}")]
        public async Task<ActionResult<ResultViewModel<ClientViewModel>>> GetClientByIdAsync(
            [FromRoute] int cliId
        )
        {
            try
            {
                var client = await clientApplication.GetClientById(cliId);
                if (client == null)
                    return NotFound(new ResultViewModel<Client>(UtilMessages.client03XE03()));

                return Ok(new ResultViewModel<ClientViewModel>(client));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Client>(UtilMessages.client03XE01(ex)));
            }
        }

        #endregion Methods
    }
}