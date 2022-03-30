using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Models
{
    public class Message
    {
        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public string message { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
