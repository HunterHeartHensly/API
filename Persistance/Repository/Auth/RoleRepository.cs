using Application.Contract.Auth;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Auth
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RepositoryContext RepoContext;
        public RoleRepository(RoleManager<IdentityRole> roleManager, RepositoryContext repoContext)
        {
            _roleManager = roleManager;
            RepoContext = repoContext;
        }
        public async Task<IdentityResult> AddRole(RoleModel roleModel)
        {
            var role = new IdentityRole
            {
                Name = roleModel.Name
            };
            var result = await _roleManager.CreateAsync(role);
            this.SaveChange();
            return result;
        }

        public IEnumerable<IdentityRole> GetAllRole()
        {
            return _roleManager.Roles.ToList();
        }

        public void SaveChange()
        {
            RepoContext.SaveChanges();
        }
    }
}
