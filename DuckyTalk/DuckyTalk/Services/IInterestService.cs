using System.Collections.Generic;

namespace DuckyTalk.Services
{
    public interface IInterestService
    {
        IEnumerable<Model.Interest> Get(Model.SearchRequests.InterestSearchRequest search);
        Model.Interest GetById(int id);

        Model.Interest Insert(Model.UpsertRequests.InterestUpsertRequest interests);

        Model.Interest Update(int id, Model.UpsertRequests.InterestUpsertRequest interests);

    }
}
