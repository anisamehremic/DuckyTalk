using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class MessageController : CRUDController<Model.Message, Model.SearchRequests.MessageSearchRequest, Model.UpsertRequests.MessageUpsertRequest, Model.UpsertRequests.MessageUpsertRequest>
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService service):base(service)
        {
            _messageService = service;
        }
    }
}
