using AutoMapper;
using DuckyTalk.Database;
using DuckyTalk.Integration.Entities.NewsApi;
using DuckyTalk.Integration.Integrations.NewsApi;
using DuckyTalk.Filters;
using DuckyTalk.Model.SearchRequests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace DuckyTalk.Services
{
    public class NewsApiService : INewsApiService
    {
        public DuckyTalkContext Context { get; set; }
        protected readonly IMapper Mapper;
        protected readonly NewsApiIntegration _newsApiIntegration;
        public NewsApiService(DuckyTalkContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            _newsApiIntegration = new NewsApiIntegration();    
        }

        public async Task<Response> Get<T>(T search) where T : Request
        {
            var interestIds = Context.UserInterests.Where(x=>x.UserId == search.UserId).Select(x=>x.InterestId).ToList();
            var interests = Context.Interests.Where(x => interestIds.Contains(x.InterestId)).ToList();
            if (!string.IsNullOrEmpty(search.Q) && interests.Any())
                search.Q += " OR ";
            
            search.Q += string.Join(" OR ", interests.Select(x => x.Name).ToList()); 

            if (string.IsNullOrEmpty(search.Q))
            {
                search.Q = "technology";
            }
            return await _newsApiIntegration.GetNewsAsync(search);
        }
    }
}
