using AspforStrapi.Services.Contract;
using AspforStrapi.Services.Contract.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
//using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AspforStrapi.Services
{
    class UserService : IUserService
    {
        private string BaseUri = "http://localhost:1337";
        public async Task<ProfileUserStrapi> GetMyInfo(string jwt)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var response = await client.GetAsync("/users/me");
            var contents = await response.Content.ReadAsStringAsync();
            ProfileUserStrapi userStrapi = JsonConvert.DeserializeObject<ProfileUserStrapi>(contents);
            return userStrapi;
        }

        public async  Task<List<ProfileUserStrapi>> UserList(string jwt)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var response = await client.GetAsync("/users");
            var contents = await response.Content.ReadAsStringAsync();
            List< ProfileUserStrapi> userList = JsonConvert.DeserializeObject<List<ProfileUserStrapi>>(contents);
            return userList;
        }
    }
}
