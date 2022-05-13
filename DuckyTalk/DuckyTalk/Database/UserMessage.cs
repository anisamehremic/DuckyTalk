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
        public DateTime DateTime { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
