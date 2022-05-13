using DuckyTalk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckyTalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class UserBreakReminderController : CRUDController<Model.UserBreakReminder, Model.SearchRequests.UserBreakReminderSearchRequest, Model.UpsertRequests.UserBreakReminderUpsertRequests, Model.UpsertRequests.UserBreakReminderUpsertRequests>
    {
        private readonly IUserBreakReminderService _userBreakReminderService;
        public UserBreakReminderController(IUserBreakReminderService service):base(service)
        {
            _userBreakReminderService = service;
        }
    }
}
