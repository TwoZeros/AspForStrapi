using System;
using System.Collections.Generic;
using System.Text;

namespace AspforStrapi.Services.Dto
{
    class UserLogin
    {
        public string identifier { get; set; }
        public string password { get; set; }
    }
}
