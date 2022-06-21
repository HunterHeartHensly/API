using Application.Contract.Auth;
using Application.Dtos.Auth;
using Application.Dtos.StudentManagement;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository RegisterRepository;
        public RegisterController(IRegisterRepository registerRepository)
        {
            RegisterRepository = registerRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {         
            var signup = await RegisterRepository.AddUser(registerModel);
            return Ok(signup);
        }


        [HttpPost]
        [Route("RegisterAddStudent")]
        public async Task<IActionResult> RegisterAddStudent(StudentModelDto studentModelDto)
        {
            var signup = await RegisterRepository.RegisterAndAddStudent(studentModelDto);
            return Ok(signup);
        }

        //[Authorize]
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            var user = RegisterRepository.GetAllUser();
            return Ok(user);
        }
    }
}
