using AutoMapper;
using DuckyTalk.Database;
using System.Collections.Generic;
using System.Linq;

namespace DuckyTalk.Services
{
    public class TechnologyService : CRUDService<Database.Technology, Model.Technology, Model.SearchRequests.TechnologySearchRequest, Model.UpsertRequests.TechnologyUpsertRequest, Model.UpsertRequests.TechnologyUpsertRequest>, ITechnologyService
    {
        public TechnologyService(DuckyTalkContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override IEnumerable<Model.Technology> Get(Model.SearchRequests.TechnologySearchRequest search = null)
        {
            var entities = Context.Set<Database.Technology>().AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                entities = entities.Where(x => x.Name.Equals(search.Name));
            }
            return Mapper.Map<List<Model.Technology>>(entities.ToList());
        }
    }
}
