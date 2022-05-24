using DuckyTalk.Integration.Entities.NewsApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DuckyTalk.Integration.Services.NewsApi
{
    public interface INewsApiService
    {
        Task<HttpResponseMessage> Get(string request);
    }
}
