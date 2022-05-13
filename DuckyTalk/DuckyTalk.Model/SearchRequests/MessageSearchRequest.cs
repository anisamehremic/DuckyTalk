using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model.SearchRequests
{
    public class MessageSearchRequest
    {
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
