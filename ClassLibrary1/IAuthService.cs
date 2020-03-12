using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspforStrapi.Services.Contract
{
    public interface IAuthService
    {

       
        
        public Task<ClaimsIdentity> GetIdentity(string username, string password);
        public bool IsCorrectUser(ClaimsIdentity claimsIdentity);
        public string getToken();
    }
}
