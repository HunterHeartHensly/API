using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Auth
{
    public interface IRoleRepository 
    {
        Task<IdentityResult> AddRole(RoleModel roleModel);
        IEnumerable<IdentityRole> GetAllRole();
        void SaveChange();
    }
}
