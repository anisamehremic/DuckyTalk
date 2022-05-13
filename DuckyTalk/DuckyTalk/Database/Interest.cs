using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class Interest
    {
        public Interest()
        {
            UserInterests = new HashSet<UserInterest>();
        }

        public int InterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserInterest> UserInterests { get; set; }
    }
}
