using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Integration.Entities.NewsApi
{
    public class TopHeadlinesRequest : Request
    {
        public string Country { get; set; }
        public string Category { get; set; }
    }
}
