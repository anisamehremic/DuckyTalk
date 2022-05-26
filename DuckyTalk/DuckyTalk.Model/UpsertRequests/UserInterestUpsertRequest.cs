using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model.UpsertRequests
{
    public class UserInterestUpsertRequest
    {
        public int UserInterestId { get; set; }
        public int UserId { get; set; }
        public int InterestId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
