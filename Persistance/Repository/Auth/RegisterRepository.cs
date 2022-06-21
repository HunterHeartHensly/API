using Application.Contract.Auth;
using Application.Dtos.Auth;
using Application.Dtos.StudentManagement;
using AutoMapper;
using Domain.Entities.Models.Auth;
using Domain.Entities.Models.StudentManagement;
using Microsoft.AspNetCore.Identity;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Auth
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        private readonly RepositoryContext RepoContext;
        private readonly IMapper _mapper;
        public RegisterRepository(RepositoryContext repoContext, 
            UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            RepoContext = repoContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddUser(RegisterModel registerModel)
        {
            //var model = _mapper.Map<RegisterModel>(registerDto);
            var user = new ApplicationUser
            {
                UserName = registerModel.UserName,
                RollNumber = registerModel.RollNumber,
                Email = registerModel.Email,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            await _userManager.AddToRoleAsync(user, registerModel.Role);
            this.SaveChange();
            return result;
        }

        public async Task<IdentityResult> RegisterAndAddStudent(StudentModelDto studentModelDto)
        {
            var user = new ApplicationUser
            {
                UserName = studentModelDto.UserName,
                RollNumber = studentModelDto.RollNumber,
                Email = studentModelDto.Email,
            };

            var result = await _userManager.CreateAsync(user, studentModelDto.Password);

            // var tempUser = await _userManager.FindByEmailAsync(registerModel.Email);
            await _userManager.AddToRoleAsync(user, "Student");
            var studentInfo = _userManager.GetUserIdAsync(user);
            var model = _mapper.Map<StudentModel>(studentModelDto);
            model.UserId = studentInfo.Result;
            await RepoContext.Students.AddAsync(model);
            this.SaveChange();
            return result;

        }

       

        public IEnumerable<IdentityUser> GetAllUser()
        {
            return _userManager.Users.ToList();
           // _userManager.
        }

        public void SaveChange()
        {
            RepoContext.SaveChanges();
        }
    }
}
