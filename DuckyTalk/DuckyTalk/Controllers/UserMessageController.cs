using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class UserMessageController : CRUDController<Model.UserMessage, Model.SearchRequests.UserMessageSearchRequest, Model.UpsertRequests.UserMessageUpsertRequest, Model.UpsertRequests.UserMessageUpsertRequest>
    {
        private readonly IUserMessageService _userMessageService;
        public UserMessageController(IUserMessageService service):base(service)
        {
            _userMessageService = service;
        }
    }
}
