using DuckyTalk.Integration.Entities.NewsApi;
using DuckyTalk.Integration.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
    
namespace DuckyTalk.Integration.Services.NewsApi
{
    public class NewsApiService : INewsApiService
    {
        private readonly HttpClient _httpClient;

        public NewsApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.NewsApi.BaseApiAddress) };
        }

        public async Task<HttpResponseMessage> Get(string request) 
        { 
            return await _httpClient.GetAsync(request);
        }
    }
}
