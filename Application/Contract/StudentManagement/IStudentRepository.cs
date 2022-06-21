using Application.Dtos.StudentManagement;
using Domain.Entities.Models.StudentManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.StudentManagement
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAllStudent();
        StudentModel GetStudentById(string id);
        void EditStudent(string id, EditStudentDto editStudentDto);
        IEnumerable<StudentModel> GetSpecificStudent(string id);
        List<StudentModel> GetSorted(SortModel sortBy);
        void SaveChange();
    }
}
