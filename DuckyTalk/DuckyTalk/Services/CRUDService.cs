using AutoMapper;
using DuckyTalk.Database;

namespace DuckyTalk.Services
{
    public class CRUDService<TDatabase, TModel, TSearch, TInsert, TUpdate>:ReadService<TDatabase, TModel, TSearch> where TDatabase:class where TModel:class where TSearch:class where TInsert:class where TUpdate:class
    {
        public CRUDService(DuckyTalkContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public virtual TModel Insert(TInsert request) {
            var set = Context.Set<TDatabase>();
            var entity = Mapper.Map<TDatabase>(request);
            set.Add(entity);
            Context.SaveChanges();
            return Mapper.Map<TModel>(entity);
}
        public virtual TModel Update(int id, TUpdate request) {
            var set = Context.Set<TDatabase>();
            var entity = set.Find(id);
            Mapper.Map(request, entity);
            Context.SaveChanges();
            return Mapper.Map<TModel>(entity);
        }
    }
}
