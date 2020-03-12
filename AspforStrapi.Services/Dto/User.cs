using System;
using System.Collections.Generic;
using System.Text;

namespace AspforStrapi.Services.Dto
{
    class User
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
