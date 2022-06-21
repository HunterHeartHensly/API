using Domain.Entities.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.StudentManagement
{
    public class EditStudentDto
    {
        //public string Id { get; set; } 
        //public string UserName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string RollNumber { get; set; }
        //public List<RoleResponse> Role { get; set; } = new List<RoleResponse>();

        //--------BasicInfo-----------//
        public string FullName { get; set; }
        public string FatherName { get; set; }
        //public string Address { get; set; }


        //--------AcademicInformation-----------//
        public string CurrentProgram { get; set; }
        public string LastProgram { get; set; }
        public string CurrentGPA { get; set; }


        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime RegistratioDate { get; set; }
        public string Status { get; set; }
    }
}
