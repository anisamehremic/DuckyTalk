using AutoMapper;
using DuckyTalk.Database;
using DuckyTalk.Filters;
using DuckyTalk.Model.SearchRequests;
using DuckyTalk.Model.UpsertRequests;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class InterestService :IInterestService
    {
        public DuckyTalkContext Context { get; set; }
        protected readonly IMapper Mapper;
        public InterestService(DuckyTalkContext context, IMapper mapper) 
        {
            Context = context;  
            Mapper = mapper;    
        }
        public IEnumerable<Model.Interest> Get(InterestSearchRequest search)
        {
            var query = Context.Interests.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                query = query.Where(x => x.Name == search.Name);
            }

            var entities = query.ToList();

            var result = Mapper.Map<IList<Model.Interest>>(entities);

            return result;
        }
        public Model.Interest GetById(int id)
        {
            var entity = Context.Interests.Find(id);

            return Mapper.Map<Model.Interest>(entity);
        }

        public Model.Interest Insert(InterestUpsertRequest request)
        {
            var entity = Mapper.Map<Database.Interest>(request);
            Context.Add(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Interest>(entity);
        }

        public Model.Interest Update(int id, InterestUpsertRequest request)
        {
            var entity = Context.Interests.Find(id);
            Mapper.Map(request, entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Interest>(entity);
        }
    }
}
