using AspforStrapi.Services.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspforStrapi.Services.Contract
{
    public interface IUserService
    {
   
        public Task<ProfileUserStrapi> GetMyInfo(string jwt);
        public Task<List<ProfileUserStrapi>> UserList(string jwt);
        
    }
}
