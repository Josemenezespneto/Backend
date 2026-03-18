using System.Security.Policy;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;

        public LoginController(IUserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginModel)
        {
            try
            {
                if (loginModel == null)
                    return BadRequest("Dados inválidos");

                var user = await _userService.GetByEmail(loginModel.Email);

                if (user == null)
                    return Unauthorized("Usuário ou senha inválidos");

                var ok = BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password);

                if (!ok)
                    return Unauthorized("Usuário ou senha inválidos");

                var token = _tokenService.GenerateToken(user);

                return Ok(new
                {
                    access_token = token,
                    user = new
                    {
                        user.Id,
                        user.Name,
                        user.Email
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}