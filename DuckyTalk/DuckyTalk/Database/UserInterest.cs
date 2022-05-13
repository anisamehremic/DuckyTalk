using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class UserInterest
    {
        public int UserInterestId { get; set; }
        public int UserId { get; set; }
        public int InterestId { get; set; }
        public bool IsActive { get; set; }
    }
}
