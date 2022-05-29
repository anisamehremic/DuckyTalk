using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class InterestController :ControllerBase
    { 
        private readonly IInterestService _service;
        public InterestController(IInterestService service)
        {
            _service = service; 
        }

        [HttpGet]
        public IEnumerable<Model.Interest> Get([FromQuery] Model.SearchRequests.InterestSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Interest GetById(int id)
        {
            return _service.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public Model.Interest Insert(Model.UpsertRequests.InterestUpsertRequest interests)
        {
            return _service.Insert(interests);
        }

        [HttpPut("{id}")]
        public Model.Interest Update(int id, [FromBody] Model.UpsertRequests.InterestUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
