using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyanNarrSinApi.Models;
using MyanNarrSinApi.Services;
using System.IdentityModel.Tokens.Jwt;

namespace MyanNarrSinApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;
        public UserController(AuthService authService)
        {
            this._authService = authService;
        }

        #region Register
        [HttpPost]
        [Route("/api/account/register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            bool isEmailDuplicate = await _authService.CheckDuplicateUserService(userModel.Email);

            if (isEmailDuplicate)
            {
                return StatusCode(StatusCodes.Status409Conflict, "User with this email already exist. Please login!");
            }
            int rows = await _authService.RegisterService(userModel);
            return rows > 0 ? Ok("Registration Success!") : BadRequest();
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("/api/account/login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel)
        {
            try
            {
                var authenticatedUser = await _authService.LoginService(userModel); // check user exists
                if (authenticatedUser != null)
                {
                    JwtSecurityToken jwtToken = _authService.GenerateToken(authenticatedUser); // generate token with encrypted claims
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    });
                }
                return BadRequest("Login Failed!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        #endregion

    }
}
