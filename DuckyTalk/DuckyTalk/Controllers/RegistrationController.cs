using DuckyTalk.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController: ControllerBase
    { 
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService service)
        {
            _registrationService = service;
        }
        [HttpPost]   
         public Model.User Insert (Model.UpsertRequests.UserUpsertRequest request)
        {
            return _registrationService.Insert(request);   
        }
        [HttpGet]
        public IEnumerable<Model.User> Get ([FromQuery]Model.SearchRequests.UserSearchRequest request)
        {
            return _registrationService.Get(request);
        }
    }
}
