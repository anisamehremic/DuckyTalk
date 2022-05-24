using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Integration.Entities.NewsApi
{
    public class EverythingRequest : Request
    {
        public string SearchIn { get; set; }
        public string Domains { get; set; }
        public string ExcludeDomains { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Language { get; set; }
        public string SortBy { get; set; }
    }
}
