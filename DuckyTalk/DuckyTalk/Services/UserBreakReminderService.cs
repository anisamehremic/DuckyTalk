using AutoMapper;
using DuckyTalk.Database;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class UserBreakReminderService : CRUDService<Database.UserBreakReminder, Model.UserBreakReminder, Model.SearchRequests.UserBreakReminderSearchRequest, Model.UpsertRequests.UserBreakReminderUpsertRequests, Model.UpsertRequests.UserBreakReminderUpsertRequests>, IUserBreakReminderService
    {
        public UserBreakReminderService(DuckyTalkContext context, IMapper mapper): base (context, mapper)
        {

        }
    }
}
