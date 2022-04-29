using DuckyTalk.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechnologyController : CRUDController<Model.Technology, Model.SearchRequests.TechnologySearchRequest, Model.UpsertRequests.TechnologyUpsertRequest, Model.UpsertRequests.TechnologyUpsertRequest>
    {
        public TechnologyController(ITechnologyService service):base(service)
        {
        }
    }
}
