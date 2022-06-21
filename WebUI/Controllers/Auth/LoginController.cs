using Application.Contract.Auth;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository LoginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await LoginRepository.Login(loginModel);
            return Ok(result);
        }
    }
}
