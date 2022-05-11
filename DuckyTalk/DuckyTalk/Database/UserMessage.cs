using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class UserMessage
    {
        public int UserMessageId { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public DateTime TimeShowed { get; set; }
    }
}
