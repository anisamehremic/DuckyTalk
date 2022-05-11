using AutoMapper;
using DuckyTalk.Database;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class UserMessageService: CRUDService<Database.UserMessage, Model.UserMessage, Model.SearchRequests.UserMessageSearchRequest, Model.UpsertRequests.UserMessageUpsertRequest, Model.UpsertRequests.UserMessageUpsertRequest>, IUserMessageService
    {
        public UserMessageService(DuckyTalkContext context, IMapper mapper): base (context, mapper)
        {

        }
    }
}
