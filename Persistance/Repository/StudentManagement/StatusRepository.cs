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
    public class StatusRepository : IStatusRepository
    {
        private readonly RepositoryContext RepoContext;
        private readonly IMapper _mapper;
        public StatusRepository(RepositoryContext repoContext, IMapper mapper)
        {
            this.RepoContext = repoContext;
            _mapper = mapper;
        }
        public void AddStatus(StatusModelDto statusModelDto)
        {
            var status = _mapper.Map<StatusModel>(statusModelDto);
            RepoContext.Status.Add(status);
            RepoContext.SaveChanges();
        }

        public IEnumerable<StatusModel> GetStatus()
        {
            return RepoContext.Status.ToList();
        }

        public void SaveChange()
        {
            RepoContext.SaveChanges();
        }
    }
}
