using Application.Contract.StudentManagement;
using Application.Dtos.StudentManagement;
using AutoMapper;
using Domain.Entities.Models.StudentManagement;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.StudentManagement
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly RepositoryContext RepoContext;
        private readonly IMapper _mapper;
        public ProgramRepository(RepositoryContext repoContext, IMapper mapper)
        {
            this.RepoContext = repoContext;
            _mapper = mapper;
        }

        public void AddProgram(AcadamiaProgramDto acadamiaProgramDto)
        {
            var program = _mapper.Map<AcadamicProgram>(acadamiaProgramDto);
            RepoContext.AcadamicPrograms.Add(program);
            RepoContext.SaveChanges();
        }

        public IEnumerable<AcadamicProgram> GetProgram()
        {
            return RepoContext.AcadamicPrograms.ToList();
        }

        public void SaveChange()
        {
            RepoContext.SaveChanges();
        }
    }
}
