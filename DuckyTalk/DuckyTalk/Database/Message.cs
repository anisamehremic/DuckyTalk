using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public string TechnologyId { get; set; }
    }
}
