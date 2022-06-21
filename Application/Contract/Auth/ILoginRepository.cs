using Domain.Entities.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Auth
{
    public class TokenVm
    {
        public string Token { get; set; }
    }
    public interface ILoginRepository
    {
        Task<TokenVm> Login(LoginModel model); 

    }
}
