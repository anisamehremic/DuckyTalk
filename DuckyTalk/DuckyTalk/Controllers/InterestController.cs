using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class InterestController : CRUDController<Model.Interest, Model.SearchRequests.InterestSearchRequest, Model.UpsertRequests.InterestUpsertRequest, Model.UpsertRequests.InterestUpsertRequest>
    {
        private readonly IInterestService _interestService;
        public InterestController(IInterestService service):base(service)
        {
            _interestService = service; 
        }
    }
}
