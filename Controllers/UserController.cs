using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using STC.Application;
using STC.DTOs.UserDto;
using STC.Extensions;
using STC.Models;
using STC.Utils;
using STC.View;

namespace STC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        #region Properties

        private UserApplication userApplication = new UserApplication();

        #endregion Properties

        #region Methods

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultViewModel<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultViewModel<User>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<string>>> CreateUser(
            [FromBody] RegisterUserDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var userVerify = await userApplication.GetUserByEmailAsync(model.UserEmail);
                if (userVerify != null)
                    return StatusCode(404, new ResultViewModel<User>(UtilMessages.user02XE05()));

                var userCreateId = await userApplication.CreateUserAsync(model);
                string userFormatted =
                    $"Id: {userCreateId} | Nome de Usuario: {model.UserName} | Email: {model.UserEmail}";

                return Ok(new ResultViewModel<string>(userFormatted, null));
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

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(ResultViewModel<string>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultViewModel<User>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<string>>> LoginUser(
            [FromBody] LoginUserDTO model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

                var userVerify = await userApplication.GetUserByEmailAsync(model.UserEmail);
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

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(ResultViewModel<string>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultViewModel<User>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultViewModel<string>>> UserProfile(
            [FromRoute] int userId
        )
        {
            try
            {
                var user = await userApplication.GetUserByIdAsync(userId);
                if (user == null)
                    return StatusCode(401, new ResultViewModel<User>(UtilMessages.user02XE06(userId)));

                string userProfile =
                    $"Cod. Usuário: {user.UserId} | Nome de Usuário: {user.UserName} | E-mail: {user.UserEmail}";

                return Ok(new ResultViewModel<string>(userProfile, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<User>(UtilMessages.user02XE01(ex)));
            }
        }

        #endregion Methods
    }
}