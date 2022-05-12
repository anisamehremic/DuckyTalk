using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public DateTime TimeShowed { get; set; }
    }
}
