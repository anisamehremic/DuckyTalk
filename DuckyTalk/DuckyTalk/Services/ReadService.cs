using AutoMapper;
using DuckyTalk.Database;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class ReadService<TDatabase, TModel, TSearch> : IReadService<TModel, TSearch> where TDatabase:class where TModel : class where TSearch: class
    {
        public DuckyTalkContext Context { get; set; }
        protected readonly IMapper Mapper;

        public ReadService(DuckyTalkContext context, IMapper mapper)
        {
            Context = context;
            Mapper=mapper;
        }
        public virtual IEnumerable<TModel> Get(TSearch search = null)
        {
            var entities = Context.Set<TDatabase>();
            return Mapper.Map<List<TModel>>(entities);
        }

        public TModel GetById(int id)
        {
            var entity = Context.Set<TDatabase>();
            return Mapper.Map<TModel>(entity.Find(id));
        }
    }
}
