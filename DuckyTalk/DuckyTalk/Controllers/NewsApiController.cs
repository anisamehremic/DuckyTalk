using DuckyTalk.Integration.Entities.NewsApi;
using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NewsApiController:ControllerBase
    {
        private readonly INewsApiService _service;

        public NewsApiController(INewsApiService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<Response> Get([FromQuery] Request request)
        {
            return _service.Get(request);
        }

        [HttpGet]
        [Route("Get/Everything")]
        public Task<Response> Get([FromQuery] EverythingRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet]
        [Route("Get/TopHeadlines")]
        public Task<Response> Get([FromQuery] TopHeadlinesRequest request)
        {
            return _service.Get(request);
        }
    }
}
