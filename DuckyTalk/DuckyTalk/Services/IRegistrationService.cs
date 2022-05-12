using System.Collections.Generic;

namespace DuckyTalk.Services
{
    public interface IRegistrationService
    {
        IEnumerable<Model.User> Get(Model.SearchRequests.UserSearchRequest search);
        Model.User Insert(Model.UpsertRequests.UserUpsertRequest korisnici);
    }
}
