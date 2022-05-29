using AutoMapper;
using DuckyTalk.Database;
using DuckyTalk.Model.SearchRequests;
using DuckyTalk.Model.UpsertRequests;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class UserInterestService :IUserInterestService
    {
        public DuckyTalkContext Context { get; set; }
        protected readonly IMapper Mapper;
        public UserInterestService(DuckyTalkContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

     
        public IEnumerable<Model.UserInterest> Get(UserInterestSearchRequest search)
        {
            var query = Context.UserInterests.AsQueryable();

            if (search?.userId != 0)
            {
                query = query.Where(x => x.UserId == search.userId);
            }

            var entities = query.ToList();

            var result = Mapper.Map<IList<Model.UserInterest>>(entities);

            return result;
        }
        public Model.UserInterest GetById(int id)
        {
            var entity = Context.UserInterests.Find(id);

            return Mapper.Map<Model.UserInterest>(entity);
        }

        public Model.UserInterest Insert(UserInterestUpsertRequest request)
        {
            var entity = Mapper.Map<Database.UserInterest>(request);
            Context.Add(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.UserInterest>(entity);
        }

        public Model.UserInterest Update(int id, UserInterestUpsertRequest request)
        {
            var entity = Context.UserInterests.Find(id);
            Mapper.Map(request, entity);
            Context.SaveChanges();
            return Mapper.Map<Model.UserInterest>(entity);
        }
    }
}
