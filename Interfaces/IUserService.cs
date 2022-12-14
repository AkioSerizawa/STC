using STC.Models;
using STC.View.UserViewModel;

namespace STC.Interfaces
{
    public interface IUserService
    {
        public Task<int> CreateUser(User registerViewModel);
        public Task<User> GetUserById(int userId);
        public Task<User> GetUserByEmail(string userEmail);
    }
}