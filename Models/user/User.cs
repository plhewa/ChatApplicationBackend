using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Models
{
    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
    }
}
