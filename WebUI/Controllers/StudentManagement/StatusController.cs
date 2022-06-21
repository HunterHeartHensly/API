using Application.Contract.StudentManagement;
using Application.Dtos.StudentManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.StudentManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository StatusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            StatusRepository = statusRepository;
        }

        //[Authorize]
        [HttpPost]
        [Route("CreateStatus")]
        public IActionResult CreateStatus(StatusModelDto statusModelDto)
        {
            StatusRepository.AddStatus(statusModelDto);
            return Ok();
        }

        //[Authorize]
        [HttpGet]
        [Route("GetStatus")]
        public IActionResult GetStatus()
        {
            var program = StatusRepository.GetStatus();
            return Ok(program);
        }
    }
}
