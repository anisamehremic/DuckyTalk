using DuckyTalk.Integration.Entities.NewsApi;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DuckyTalk.Services
{
    public interface INewsApiService
    {
       Task<Response> Get<T>(T search) where T : Request;
    }
}
