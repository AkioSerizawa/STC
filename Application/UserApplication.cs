using SecureIdentity.Password;
using STC.DTOs.UserDto;
using STC.Models;
using STC.Services;
using STC.View.UserViewModel;

namespace STC.Application;

public class UserApplication
{
    #region Properties

    private UserService userService = new UserService();

    #endregion Properties

    #region Methods

    public async Task<int> CreateUserAsync(RegisterUserDTO model)
    {
        var user = new User
        {
            UserName = model.UserName,
            UserEmail = model.UserEmail,
            UserPassword = PasswordHasher.Hash(model.UserPassword)
        };

        var userCreateId = await userService.CreateUser(user);
        return userCreateId;
    }

    public async Task<UserViewModel> GetUserByEmailAsync(string userEmail)
    {
        var user = await userService.GetUserByEmail(userEmail);

        var userView = new UserViewModel
        {
            UserId = user.UserId,
            UserEmail = user.UserEmail,
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };

        return userView;
    }

    public async Task<UserViewModel> GetUserByIdAsync(int userId)
    {
        var user = await userService.GetUserById(userId);
        
        var userView = new UserViewModel
        {
            UserId = user.UserId,
            UserEmail = user.UserEmail,
            UserName = user.UserName,
            UserPassword = user.UserPassword
        };
        
        return userView;
    }

    #endregion Methods
}