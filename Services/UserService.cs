using Microsoft.EntityFrameworkCore;
using STC.Data;
using STC.Interfaces;
using STC.Models;

namespace STC.Services
{
    public class UserService : IUserService
    {
        public async Task<int> CreateUser(User registerViewModel)
        {
            try
            {
                using var context = new DataContext();

                await context.Users.AddAsync(registerViewModel);
                await context.SaveChangesAsync();

                return registerViewModel.UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                using var context = new DataContext();

                List<User> users = await context.Users
                        .AsNoTracking()
                        .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            try
            {
                using var context = new DataContext();

                User user = await context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.UserEmail.Contains(userEmail));

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            try
            {
                using var context = new DataContext();

                User user = await context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.UserId == userId);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}