using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserInterestController 
    { 
        private readonly IUserInterestService _service;
        public UserInterestController(IUserInterestService service)
        {
            _service = service;
        }

 

        [HttpGet]
        public IEnumerable<Model.UserInterest> Get([FromQuery] Model.SearchRequests.UserInterestSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public Model.UserInterest GetById(int id)
        {
            return _service.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public Model.UserInterest Insert(Model.UpsertRequests.UserInterestUpsertRequest interests)
        {
            return _service.Insert(interests);
        }

        [HttpPut("{id}")]
        public Model.UserInterest Update(int id, [FromBody] Model.UpsertRequests.UserInterestUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
