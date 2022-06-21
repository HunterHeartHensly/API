using Application.Contract.Auth;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository RoleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleModel roleModel)
        {
            await RoleRepository.AddRole(roleModel);
            return Ok();
        }

        //[Authorize]
        [HttpGet]
        [Route("GetRole")]
        public IActionResult GetRole()
        {
            var role = RoleRepository.GetAllRole();
            return Ok(role);
        }
    }
}
