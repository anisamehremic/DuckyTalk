using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController:ControllerBase
    {
        private readonly IUsersService _service;

        public UserController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Model.User> Get([FromQuery] Model.SearchRequests.UserSearchRequest request)
        {
            return _service.Get(request);
        }
        
        [HttpGet("{id}")]
        public Model.User GetById(int id)
        {
            return _service.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public Model.User Insert(Model.UpsertRequests.UserUpsertRequest korisnici)
        {
            return _service.Insert(korisnici);
        }

        [HttpPut("{id}")]
        public Model.User Update(int id, [FromBody] Model.UpsertRequests.UserUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
