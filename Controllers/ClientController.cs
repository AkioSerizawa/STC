using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STC.Extensions;
using STC.Helpers;
using STC.Models;
using STC.Services;
using STC.Utils;
using STC.View;
using STC.View.ClientViewModel;

namespace STC.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientHelper clientHelper = new ClientHelper();
        private ClientService clientService = new ClientService();

        [HttpPost("v1/client")]
        public async Task<IActionResult> CreateClientAsync(
            [FromBody] CreateClienteViewModel model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var client = await clientHelper.CreateClient(model);
                string clientFormatted = $"Cliente criado com sucesso - Id: {client.CliId} | Nome do Cliente: {client.CliName}";

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

        [HttpGet("v1/client")]
        public async Task<IActionResult> GetClientsAsync()
        {
            try
            {
                List<Client> clients = await clientService.GetUsers();
                if (clients.Count == 0)
                    return NotFound(new ResultViewModel<Client>(UtilMessages.client03XE03()));

                return Ok(new ResultViewModel<List<Client>>(clients));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Client>(UtilMessages.client03XE01(ex)));
            }
        }

        [HttpGet("v1/client/{cliId:int}")]
        public async Task<IActionResult> GetClientByIdAsync(
            [FromRoute] int cliId
        )
        {
            try
            {
                Client client = await clientService.GetUserById(cliId);
                if (client == null)
                    return NotFound(new ResultViewModel<Client>(UtilMessages.client03XE03()));

                return Ok(new ResultViewModel<Client>(client));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Client>(UtilMessages.client03XE01(ex)));
            }
        }
    }
}