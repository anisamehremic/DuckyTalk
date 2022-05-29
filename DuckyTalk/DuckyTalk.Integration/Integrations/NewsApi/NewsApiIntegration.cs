using DuckyTalk.Integration.Entities.NewsApi;
using DuckyTalk.Integration.Helpers;
using DuckyTalk.Integration.Services.NewsApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DuckyTalk.Integration.Integrations.NewsApi
{
    public class NewsApiIntegration
    {
        private readonly NewsApiService _newsApiService;
        public NewsApiIntegration()
        {
            _newsApiService = new NewsApiService();
        }
        public async Task<Response> GetNewsAsync(Request request) {
            var response = await _newsApiService.Get(PrepareDataForGetMethod(request));
            return DeserializeResponse(response);
        }
        private string PrepareDataForGetMethod<T>(T request) where T : Request
        {
            List<string> apiMethods = new List<string>();
            apiMethods.Add($"{(request is TopHeadlinesRequest ? Constants.NewsApi.TopHeadlinesPath : Constants.NewsApi.EverythingPath)}?apiKey={Constants.NewsApi.ApiKey}");

            if (!string.IsNullOrEmpty(request.Q))
                apiMethods.Add($"q={request.Q}");
            if (!string.IsNullOrEmpty(request.Sources))
                apiMethods.Add($"sources={request.Sources}");
            if (request.PageSize.GetValueOrDefault() != 0)
                apiMethods.Add($"pageSize={request.PageSize.Value}");
            if (request.Page.GetValueOrDefault() != 0)
                apiMethods.Add($"page={request.Page.Value}");

            if (request is TopHeadlinesRequest)
            {
                if (!string.IsNullOrEmpty((request as TopHeadlinesRequest).Country))
                    apiMethods.Add($"country={(request as TopHeadlinesRequest).Country}");
                if (!string.IsNullOrEmpty((request as TopHeadlinesRequest).Category))
                    apiMethods.Add($"category={(request as TopHeadlinesRequest).Category}");
            }
            else if (request is EverythingRequest)
            {
                if (!string.IsNullOrEmpty((request as EverythingRequest).SearchIn))
                    apiMethods.Add($"country={(request as EverythingRequest).SearchIn}");
                if (!string.IsNullOrEmpty((request as EverythingRequest).Domains))
                    apiMethods.Add($"domains={(request as EverythingRequest).Domains}");
                if (!string.IsNullOrEmpty((request as EverythingRequest).ExcludeDomains))
                    apiMethods.Add($"excludeDomains={(request as EverythingRequest).ExcludeDomains}");
                if ((request as EverythingRequest).From != null)
                    apiMethods.Add($"from={(request as EverythingRequest).From.Value.ToString("yyyy-MM-dd")}");
                if ((request as EverythingRequest).To != null)
                    apiMethods.Add($"to={(request as EverythingRequest).To.Value.ToString("yyyy-MM-dd")}");
                if (!string.IsNullOrEmpty((request as EverythingRequest).Language))
                    apiMethods.Add($"language={(request as EverythingRequest).Language}");
                if (!string.IsNullOrEmpty((request as EverythingRequest).SortBy))
                    apiMethods.Add($"sortBy={(request as EverythingRequest).SortBy}");
            }

            return string.Join("&", apiMethods);
        }
        private Response DeserializeResponse(HttpResponseMessage response)
        {
            if(response != null)
                return JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);
            return null;
        }
    }
}
