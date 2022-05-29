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

        public async Task<HttpResponseMessage> Get(string requestString) 
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, requestString))
            {

                request.Headers.Add("User-Agent", "Mozilla/5.0");
                var response = await _httpClient.SendAsync(request);

                return response;
            }
            
        }
    }
}
