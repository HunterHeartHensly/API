using Application.Dtos.StudentManagement;
using Domain.Entities.Models.StudentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.StudentManagement
{
    public interface IProgramRepository
    {
        void AddProgram(AcadamiaProgramDto acadamiaProgramDto); 
        IEnumerable<AcadamicProgram> GetProgram(); 
        void SaveChange();
    }
}
