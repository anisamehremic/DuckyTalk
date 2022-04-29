using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuckyTalk.Controllers
{
    [Authorize]
    public class CRUDController<TModel, TSearch, TInsert, TUpdate>:ReadController<TModel, TSearch> where TModel:class where TSearch:class where TInsert:class where TUpdate:class
    {
        protected readonly ICRUDService<TModel, TSearch, TInsert, TUpdate> _crudService;
        public CRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service):base(service)
        {
            _crudService = service;
        }
        [HttpPost]
        public TModel Insert([FromBody] TInsert request)
        {
            return _crudService.Insert(request);
        }
        
        [HttpPut("{id}")]
        public TModel Insert(int id, [FromBody] TUpdate request)
        {
            return _crudService.Update(id, request);
        }
    }
}
