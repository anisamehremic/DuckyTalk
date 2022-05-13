using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserInterestController : CRUDController<Model.UserInterest, Model.SearchRequests.UserInterestSearchRequest, Model.UpsertRequests.UserInterestUpsertRequest, Model.UpsertRequests.UserInterestUpsertRequest>
    {
        private readonly IUserInterestService _userInterestService;
        public UserInterestController(IUserInterestService service):base(service)
        {
            _userInterestService = service;
        }
    }
}
