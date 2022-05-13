using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class UserTechnology
    {
        public int UserTechnologyId { get; set; }
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Technology Technology { get; set; }
        public virtual User User { get; set; }
    }
}
