using Application.Dtos.Auth;
using Application.Dtos.StudentManagement;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Auth
{
    public interface IRegisterRepository
    {
        Task<IdentityResult> AddUser(RegisterModel registerModel);
        Task<IdentityResult> RegisterAndAddStudent(StudentModelDto studentModelDto);
        IEnumerable<IdentityUser> GetAllUser();
        void SaveChange();
    }
}
