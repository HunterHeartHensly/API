using Application.Contract.StudentManagement;
using Application.Dtos.StudentManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.StudentManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {

        private readonly IProgramRepository ProgramRepository;
        public ProgramController(IProgramRepository programRepository)
        {
            ProgramRepository = programRepository;
        }

        //[Authorize]
        [HttpPost]
        [Route("CreateProgram")]
        public IActionResult CreateProgram(AcadamiaProgramDto acadamiaProgramDto)
        {
            ProgramRepository.AddProgram(acadamiaProgramDto);
            return Ok();
        }

        //[Authorize]
        [HttpGet]
        [Route("GetProgram")]
        public IActionResult GetProgram()
        {
            var program = ProgramRepository.GetProgram();
            return Ok(program);
        }
    }
}
