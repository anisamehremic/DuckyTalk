using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Integration.Helpers
{
    public class Constants
    {
        public static class NewsApi
        {
            public const string BaseApiAddress = @"https://newsapi.org";
            public const string ApiKey = "920129c084aa4819a0f0d3487efbe1ae";

            public const string EverythingPath = @"/v2/everything";
            public const string TopHeadlinesPath = @"/v2/top-headlines";
        }
    }
}
