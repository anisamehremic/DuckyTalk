using System.Collections.Generic;

namespace DuckyTalk.Services
{
    public interface IUserInterestService
    {
        IEnumerable<Model.UserInterest> Get(Model.SearchRequests.UserInterestSearchRequest search);
        Model.UserInterest GetById(int id);

        Model.UserInterest Insert(Model.UpsertRequests.UserInterestUpsertRequest interests);

        Model.UserInterest Update(int id, Model.UpsertRequests.UserInterestUpsertRequest interests);
    }
}
