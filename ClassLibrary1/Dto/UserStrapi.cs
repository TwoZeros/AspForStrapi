using System;
using System.Collections.Generic;
using System.Text;

namespace AspforStrapi.Services.Contract.Dto
{
    public class UserStrapi
    {
        public string jwt { get; set; }
        public UserObject user { get; set; }
        
    }

    public class UserObject
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public RoleStrapi role { get; set; }
    }
    public class RoleStrapi
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
