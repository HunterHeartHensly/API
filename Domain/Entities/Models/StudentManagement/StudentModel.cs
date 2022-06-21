using Domain.Entities.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.StudentManagement
{
    public class StudentModel
    {
        public StudentModel()
        {
            this.RegistratioDate = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        //--------BasicInfo-----------//
        public string FullName  { get; set; }
        public string FatherName { get; set; }

        //public string Address { get; set; }


        //--------AcademicInformation-----------//
        public string CurrentProgram { get; set; }
        public string LastProgram { get; set; }
        public string CurrentGPA { get; set; }


        [DataType(DataType.Date)]//{0:yyyy/MM/dd} {0:dd/MM/yyyy}
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime RegistratioDate { get; set; } 
        public string Status { get; set; }
        public string RollNumber { get; set; }


       // [Key, ForeignKey("ApplicationUser")]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
