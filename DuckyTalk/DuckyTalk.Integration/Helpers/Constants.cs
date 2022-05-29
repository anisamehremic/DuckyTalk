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
            public const string ApiKey = "b3fd10451b1e46cd971dcf15d4bd9cd7";

            public const string EverythingPath = @"/v2/everything";
            public const string TopHeadlinesPath = @"/v2/top-headlines";
        }
    }
}
