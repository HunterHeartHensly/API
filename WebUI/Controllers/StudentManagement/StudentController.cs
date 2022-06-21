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
            var student = _studentRepository.GetAllStudent();
            return Ok(student);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(string id)
        {
            var student = _studentRepository.GetStudentById(id);
            return Ok(student);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("EditStudent/{id}")]
        public IActionResult EditStudent(string id, EditStudentDto editStudentDto)
        {
            _studentRepository.EditStudent(id, editStudentDto);
            return Ok();
        }


        //[Authorize(Roles = "Student")]
        [HttpGet]
        [Route("SpecificStudent/{id}")]
        public IActionResult SpecificStudent(string id)
        {
            var student = _studentRepository.GetSpecificStudent(id);
            return Ok(student);
        }


        //[Authorize]
        [HttpPost("Sorting")]
        public IActionResult Sorting(SortModel sortBy)
        {
            var sort = _studentRepository.GetSorted(sortBy);
            return Ok(sort);
        }
    }
}
