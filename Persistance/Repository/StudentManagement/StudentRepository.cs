using Application.Contract.StudentManagement;
using Application.Dtos.StudentManagement;
using AutoMapper;
using Domain.Entities.Models.Auth;
using Domain.Entities.Models.StudentManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.StudentManagement
{
   
    public class StudentRepository : IStudentRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RepositoryContext RepoContext; 
        private readonly IMapper _mapper;
        public StudentRepository(RepositoryContext repoContext, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.RepoContext = repoContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        
        public IEnumerable<StudentModel> GetAllStudent()
        {
            //int x = 10;
            //int y =20;
            //int z = x+y;
            //console.log(z);


            //int z1 = x/y;
            //console.log(z1);


            return RepoContext.Students.ToList();
        }

        public StudentModel GetStudentById(string id)
        {
            return RepoContext.Students.SingleOrDefault(x => x.Id == id);
        }

        public void EditStudent(string id, EditStudentDto editStudentDto)
        {
            var result = this.GetStudentById(id);

            if (result != null)
            {
                _mapper.Map(editStudentDto, result);
                 RepoContext.SaveChanges();
            }
        }

        public IEnumerable<StudentModel> GetSpecificStudent(string id) 
        {
            // return RepoContext.Students.SingleOrDefault(x => x.Id == id);

            // return RepoContext.Students
            //.Include(dep => dep.AspNetUsers)
            //.FirstOrDefault(x => x.Id == id);
            
            return RepoContext.Students.Where(x => x.UserId == id);

            
        }


        public List<StudentModel> GetSorted(SortModel sortBy)
        {
            var queryable = RepoContext.Students;

            var student = new List<StudentModel>();

            if (sortBy.direction.Trim().ToLower() == "asc") 
            {
                student = queryable
                .OrderBy(x => x.RegistratioDate).ToList();
            }

            else if (sortBy.direction.Trim().ToLower() == "desc")
            {
                student = queryable
                .OrderByDescending(x => x.RegistratioDate).ToList();
            }

            else if (sortBy.direction == "")
            {
                student = queryable
               .OrderBy(x => x.RegistratioDate).ToList();
            }
            return student;

        }

        public void SaveChange()
        {
            RepoContext.SaveChanges();
        }
    }
}
