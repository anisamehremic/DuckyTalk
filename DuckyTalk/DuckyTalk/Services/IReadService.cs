using System.Collections.Generic;

namespace DuckyTalk.Services
{
    public interface IReadService<TModel, TSearch> where TModel:class where TSearch:class
    {
        public IEnumerable<TModel> Get(TSearch search = null);
        public TModel GetById(int id);
    }
}
