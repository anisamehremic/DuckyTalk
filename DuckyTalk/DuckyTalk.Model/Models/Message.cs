using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public string Keywords { get; set; }

        public string TechnologyId { get; set; }
    }
}
