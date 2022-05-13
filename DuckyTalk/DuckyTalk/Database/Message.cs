using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class Message
    {
        public Message()
        {
            UserMessages = new HashSet<UserMessage>();
        }

        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public string Keywords { get; set; }
        public int TechnologyId { get; set; }

        public virtual Technology Technology { get; set; }
        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
