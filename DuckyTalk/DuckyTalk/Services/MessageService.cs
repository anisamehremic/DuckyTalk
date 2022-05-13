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

            var allMessagesForUser = Context.Messages.Where(x => technologyIds.Contains(x.TechnologyId));
            var userMessages = Context.UserMessages.Where(x => x.UserId.Equals(search.UserId)).Distinct().OrderBy(y => y.DateTime);
            var userMessageMessageIds = userMessages.Select(x => x.MessageId);
            var messagesWithKeywords = allMessagesForUser.Where(x => search.Content.Contains(x.Keywords));

            Message message = new Message();

            if (messagesWithKeywords.Any())
            {
                if (userMessages.Any())
                {
                    if (messagesWithKeywords.Where(x => userMessageMessageIds.Contains(x.MessageId)).Count() < messagesWithKeywords.Count())
                    {
                        message = messagesWithKeywords.Where(x => !userMessageMessageIds.Contains(x.MessageId)).FirstOrDefault();
                    }
                    else
                    {
                        message = messagesWithKeywords.Where(x => x.MessageId.Equals(userMessages.OrderBy(x => x.DateTime).FirstOrDefault().MessageId)).FirstOrDefault();
                    }
                }
                else
                {
                    message = messagesWithKeywords.FirstOrDefault();
                }
            }
            else
            {
                if (userMessages.Any())
                {
                    if (allMessagesForUser.Where(x => string.IsNullOrEmpty(x.Keywords) && userMessageMessageIds.Contains(x.MessageId)).Count() < messagesWithKeywords.Count())
                    {
                        message = allMessagesForUser.Where(x => string.IsNullOrEmpty(x.Keywords) && !userMessageMessageIds.Contains(x.MessageId)).FirstOrDefault();
                    }
                    else
                    {
                        message = allMessagesForUser.Where(x => string.IsNullOrEmpty(x.Keywords) && x.MessageId.Equals(userMessages.OrderBy(x => x.DateTime).FirstOrDefault().MessageId)).FirstOrDefault();
                    }
                }
                else
                {
                    message = Context.Messages.Where(x => string.IsNullOrEmpty(x.Keywords)).FirstOrDefault();
                }
            }

            Context.UserMessages.Add(new UserMessage { UserId = search.UserId, MessageId = message.MessageId, DateTime = System.DateTime.Now, IsDeleted = false });
            Context.SaveChanges();
            var messageToSend = Mapper.Map<IEnumerable<Model.Message>>(message);
            return messageToSend;
        }
    }
}
