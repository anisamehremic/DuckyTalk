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
        public override IEnumerable<Model.Message> Get(MessageSearchRequest search = null)
        {
            var userTechnologies = Context.UserTechnologies.Where(x => x.UserId.Equals(search.UserId));
            var technologyIds = userTechnologies.Select(x => x.TechnologyId).ToList();
            var allMessagesForUser = Context.Messages.Where(x => technologyIds.Contains(x.TechnologyId));//all messsages for all technologies user checked
            var userMessages = Context.UserMessages.Where(x => x.UserId.Equals(search.UserId)).OrderBy(y=>y.dateTime);
            var messagesWithKeywords = allMessagesForUser.Where(x => search.Content.Contains(x.Keywords));

            Message message;
            if (messagesWithKeywords.Any())
            {
                message = new Database.Message();
            }
            else { 
                message= new Database.Message();
            }

            Context.UserMessages.Add(new UserMessage { UserId = search.UserId, MessageId = message.MessageId, dateTime = System.DateTime.Now, IsDeleted = false });

            var messageToSend = Mapper.Map<Model.Message>(message);
            return messageToSend;
        }
    }
}
