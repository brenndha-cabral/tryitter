using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tryitter.Interfaces;
using tryitter.Models;
using tryitter.Repository;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly ILogin _loginRepository;

        public LoginController(ILogin loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var token = await _loginRepository.TokenGenerate(login.Email, login.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token not generated, invalid credentials. Please try again.");
            }

            return Ok(token);
        }
    }
}
