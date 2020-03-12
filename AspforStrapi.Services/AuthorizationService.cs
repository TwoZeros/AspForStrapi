using AspforStrapi.Services.Contract;
using System;
using System.Collections.Generic;
using System.Security.Claims;

using AspforStrapi.Services.Dto;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using AspforStrapi.Services.Contract.Dto;

namespace AspforStrapi.Services
{
    public class AuthorizationService : IAuthService
    {

        private UserStrapi userStrapi;
        public async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {

            var userLogin = new UserLogin
            {
                identifier = username,
                password = password
            };
            var json = JsonConvert.SerializeObject(userLogin);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://localhost:1337/auth/local";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            if(response == null)
            {
                return null;
            }
            var contents = await response.Content.ReadAsStringAsync();
            userStrapi = JsonConvert.DeserializeObject<UserStrapi>(contents);

            if (userStrapi.jwt != null)
            {
                var claims = new List<Claim>()
                    {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userStrapi.user.username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userStrapi.user.role.name),
                    };
                // создаем объект ClaimsIdentity
                ClaimsIdentity claimsId = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                
                // установка аутентификационных куки
                return claimsId;
            }
            return null;

        }
        public string getToken()
        {
            return userStrapi.jwt;
        }

        public bool IsCorrectUser(ClaimsIdentity claimsIdentity)
        {
            return claimsIdentity != null;
        }

          
    }
}
