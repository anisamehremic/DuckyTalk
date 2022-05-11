using AutoMapper;
using DuckyTalk.Database;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class UserInterestService: CRUDService<Database.UserInterest, Model.UserInterest, Model.SearchRequests.UserInterestSearchRequest, Model.UpsertRequests.UserInterestUpsertRequest, Model.UpsertRequests.UserInterestUpsertRequest>, IUserInterestService
    {
        public UserInterestService(DuckyTalkContext context, IMapper mapper): base (context, mapper)
        {

        }
    }
}
