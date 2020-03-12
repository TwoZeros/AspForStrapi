using System;
using System.Collections.Generic;
using System.Text;

namespace AspforStrapi.Services.Contract.Dto
{
    public class ProfileUserStrapi
    {
        public string jwt { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public RoleStrapi role { get; set; }

    }

 
  
}
