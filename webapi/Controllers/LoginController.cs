using FluentAssertions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceitaWSAPI.Application.Interfaces;
using ReceitaWSAPI.Application.Models;
using ReceitaWSAPI.Domain.Entities;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginAppService _service;

        public LoginController(ILoginAppService loginAppService) 
        {
            _service = loginAppService ?? throw new ArgumentNullException(nameof(loginAppService));
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> VerifyLoginAsync([FromBody] LoginViewModel loginViewModel)
        {
            var user =  await _service.VerifyLogin(loginViewModel);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token,
            };
        }
    }
}
