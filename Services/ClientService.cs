using Microsoft.EntityFrameworkCore;
using STC.Data;
using STC.Interfaces;
using STC.Models;

namespace STC.Services
{
    public class ClientService : IClientService
    {
        public async Task<Client> CreateClient(Client model)
        {
            try
            {
                using var context = new DataContext();

                await context.Client.AddAsync(model);
                await context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> GetUserById(int cliId)
        {
            try
            {
                using var context = new DataContext();

                Client client = await context.Client
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CliId == cliId);

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Client>> GetAllUser()
        {
            try
            {
                using var context = new DataContext();

                List<Client> clients = await context.Client
                    .AsNoTracking()
                    .ToListAsync();

                return clients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}