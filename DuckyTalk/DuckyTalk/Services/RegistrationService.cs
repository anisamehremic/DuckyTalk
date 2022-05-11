using AutoMapper;
using DuckyTalk.Database;
using DuckyTalk.Filters;
using DuckyTalk.Helpers;
using DuckyTalk.Model.SearchRequests;
using DuckyTalk.Model.UpsertRequests;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class RegistrationService: CRUDService<Database.User, Model.User, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>, IRegistrationService
    {
        public RegistrationService(DuckyTalkContext context, IMapper mapper): base (context, mapper)
        {

        }
        public override Model.User Insert(UserUpsertRequest request)
        {
            var entity = Mapper.Map<Database.User>(request);
            Context.Add(entity);
            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Passwords do not match.");
            }

            entity.PasswordSalt = CrypthographyHelper.GenerateSalt();
            entity.PasswordHash = CrypthographyHelper.GenerateHash(entity.PasswordSalt, request.Password);

            Context.SaveChanges();

            return Mapper.Map<Model.User>(entity);
        }
        public override IEnumerable<Model.User> Get(UserSearchRequest search = null) {

            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username == search.Username);
            }

            var entities = query.ToList();
            var result = Mapper.Map<IList<Model.User>>(entities);
            return result;
        }
    }
}
