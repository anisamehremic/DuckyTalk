using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class User
    {
        public User()
        {
            UserBreakReminders = new HashSet<UserBreakReminder>();
            UserInterests = new HashSet<UserInterest>();
            UserMessages = new HashSet<UserMessage>();
            UserTechnologies = new HashSet<UserTechnology>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Gender { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<UserBreakReminder> UserBreakReminders { get; set; }
        public virtual ICollection<UserInterest> UserInterests { get; set; }
        public virtual ICollection<UserMessage> UserMessages { get; set; }
        public virtual ICollection<UserTechnology> UserTechnologies { get; set; }
    }
}
