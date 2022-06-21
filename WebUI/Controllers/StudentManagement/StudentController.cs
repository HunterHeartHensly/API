using Application.Contract.StudentManagement;
using Application.Dtos.StudentManagement;
using Domain.Entities.Models.StudentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.StudentManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            //int x = 10;
            //int y =20;
            //int z = x+y;
            //console.log(z);


            //int z1 = x/y;
            //console.log(z1);

            var student = _studentRepository.GetAllStudent();
            return Ok(student);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(string id)
        {
            //int x = 10;
            //int y =20;
            //int z = x+y;
            //console.log(z);


            //int z1 = x/y;
            //console.log(z1);

            var student = _studentRepository.GetStudentById(id);
            return Ok(student);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("EditStudent/{id}")]
        public IActionResult EditStudent(string id, EditStudentDto editStudentDto)
        {
            //int x = 10;
            //int y =20;
            //int z = x+y;
            //console.log(z);


            //int z1 = x/y;
            //console.log(z1);

            _studentRepository.EditStudent(id, editStudentDto);
            return Ok();
        }


        //[Authorize(Roles = "Student")]
        [HttpGet]
        [Route("SpecificStudent/{id}")]
        public IActionResult SpecificStudent(string id)
        {
            //int x = 10;
            //int y =20;
            //int z = x+y;
            //console.log(z);


            //int z1 = x/y;
            //console.log(z1);

            var student = _studentRepository.GetSpecificStudent(id);
            return Ok(student);
        }


        //[Authorize]
        [HttpPost("Sorting")]
        public IActionResult Sorting(SortModel sortBy)
        {
            //int x = 10;
            //int y =20;
            //int z = x+y;
            //console.log(z);


            //int z1 = x/y;
            //console.log(z1);
            var sort = _studentRepository.GetSorted(sortBy);
            return Ok(sort);
        }
    }
}
