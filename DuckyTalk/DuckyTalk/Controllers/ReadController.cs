using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ReadController<TModel, TSearch> : ControllerBase where TModel : class where TSearch:class
    {
        private readonly IReadService<TModel, TSearch> _service;
        public ReadController(IReadService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IEnumerable<TModel> Get([FromQuery]TSearch search)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public TModel GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
