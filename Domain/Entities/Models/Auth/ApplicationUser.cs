using Domain.Entities.Models.StudentManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public virtual StudentModel StudentModel { get; set; }
        public string RollNumber { get; set; }
    }
}
