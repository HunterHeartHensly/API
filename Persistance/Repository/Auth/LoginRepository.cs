using Application.Contract.Auth;
using Domain.Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Auth
{
    public class LoginRepository : ILoginRepository
    {
        private readonly RepositoryContext RepoContext;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;
        public LoginRepository(RepositoryContext repoContext , UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this.RepoContext = repoContext;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<TokenVm> Login(LoginModel model)
        {
            //throw new NotImplementedException();  
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get Role assigned to user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var claims = new List<Claim>()
                {
                     new Claim("UserID",user.Id.ToString())
                    
                };

                claims.AddRange(role.Select(role => new Claim(ClaimTypes.Role, role)));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                //JObject json = JObject.Parse(token);
                return new TokenVm
                {
                    Token = token
                };

            }
            else throw new Exception("False");
        }
    }


   
}
