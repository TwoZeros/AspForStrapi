using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspforStrapi.Data
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
    }
}
