using AutoMapper;
using DuckyTalk.Database;
using DuckyTalk.Model.SearchRequests;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class MessageService : CRUDService<Database.Message, Model.Message, Model.SearchRequests.MessageSearchRequest, Model.UpsertRequests.MessageUpsertRequest, Model.UpsertRequests.MessageUpsertRequest>, IMessageService
    {
        public MessageService(DuckyTalkContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
