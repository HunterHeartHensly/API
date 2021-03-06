using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.Auth
{
    public class StudentRegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RollNumber { get; set; }

        
        public List<RoleResponse> Role { get; set; } = new List<RoleResponse>();
    }
}
