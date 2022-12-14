using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using STC.Extensions;
using STC.Models;
using STC.Services;
using STC.Utils;
using STC.View;
using STC.View.UserViewModel;

namespace STC.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService = new UserService();

        [HttpPost("v1/user")]
        public async Task<IActionResult> CreateUser(
            [FromBody] RegisterViewModel model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var userVerify = await userService.GetUserByEmail(model.UserEmail);
                if (userVerify != null)
                    return StatusCode(404, new ResultViewModel<User>(UtilMessages.user02XE05()));

                var user = new User
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    UserPassword = PasswordHasher.Hash(model.UserPassword)
                };

                var userCreateId = await userService.CreateUser(user);
                string userFormatted = $"Id: {userCreateId} | Nome de Usuario: {model.UserName} | Email: {model.UserEmail}";

                return Ok(new ResultViewModel<dynamic>(userFormatted, null));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400, new ResultViewModel<User>(UtilMessages.user02XE02(ex)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<User>(UtilMessages.user02XE01(ex)));
            }
        }

        [HttpPost("v1/user/login")]
        public async Task<IActionResult> LoginUser(
            [FromBody] LoginViewModel model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var userVerify = await userService.GetUserByEmail(model.UserEmail);
                if (userVerify == null)
                    return StatusCode(401, new ResultViewModel<User>(UtilMessages.user02XE03()));

                if (!PasswordHasher.Verify(userVerify.UserPassword, model.UserPassword))
                    return StatusCode(401, new ResultViewModel<User>(UtilMessages.user02XE04()));

                return StatusCode(202, new ResultViewModel<string>($"Usuario logado - {userVerify.UserName}", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<User>(UtilMessages.user02XE01(ex)));
            }
        }
    }
}