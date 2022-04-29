using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuckyTalk.Services
{
    public interface IUsersService
    {
        IEnumerable<Model.User> Get(Model.SearchRequests.UserSearchRequest search);

        Model.User GetById(int id);

        Model.User Insert(Model.UpsertRequests.UserUpsertRequest korisnici);

        Model.User Update(int id, Model.UpsertRequests.UserUpsertRequest korisnici);

        Task<Model.User> Login(string username, string password);
    }
}
