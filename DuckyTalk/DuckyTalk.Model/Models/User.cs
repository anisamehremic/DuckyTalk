using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
