using STC.Models;

namespace STC.Interfaces
{
    public interface IClientService
    {
        public Task<Client> CreateClient(Client model);
        public Task<List<Client>> GetAllUser();
        public Task<Client> GetUserById(int cliId);
    }
}