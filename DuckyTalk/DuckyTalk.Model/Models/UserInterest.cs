using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class UserInterest
    {
        public int UserInterestId { get; set; }
        public int UserId { get; set; }
        public string InterestId { get; set; }
        public bool IsActive { get; set; }
    }
}
