using AutoMapper;
using DuckyTalk.Database;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class InterestService: CRUDService<Database.Interest, Model.Interest, Model.SearchRequests.InterestSearchRequest, Model.UpsertRequests.InterestUpsertRequest, Model.UpsertRequests.InterestUpsertRequest>, IInterestService
    {
        public InterestService(DuckyTalkContext context, IMapper mapper): base (context, mapper)
        {

        }
    }
}
