using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class Technology
    {
        public Technology()
        {
            Messages = new HashSet<Message>();
            UserTechnologies = new HashSet<UserTechnology>();
        }

        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserTechnology> UserTechnologies { get; set; }
    }
}
