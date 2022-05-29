using DuckyTalk.Helpers;
using AutoMapper;
using DuckyTalk.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using DuckyTalk.Model.SearchRequests;
using DuckyTalk.Model.UpsertRequests;
using System.Linq;
using DuckyTalk.Filters;
using System;

namespace DuckyTalk.Services
{
    public class UsersService : IUsersService
    {
        public DuckyTalkContext Context { get; set; }
        protected readonly IMapper Mapper;

        public UsersService(DuckyTalkContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task<Model.User> Login(string username, string password)
        {
            var entity = await Context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (entity == null)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var hash = CrypthographyHelper.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var userBreakReminder = Context.UserBreakReminders.FirstOrDefault(x=> x.UserId == entity.UserId);
            if (userBreakReminder?.BreakNotificationsEnabled ??  false)
                UserBreakReminderHelper.BreakNotification();

            if(userBreakReminder?.EndTimeNotificationsEnabled ?? false)
                UserBreakReminderHelper.EndTimeNotification(DateTime.Now);  

            return Mapper.Map<Model.User>(entity);
        }

        public IEnumerable<Model.User> Get(UserSearchRequest search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.FirstName))
            {
                query = query.Where(x => x.FirstName == search.FirstName);
            }

            var entities = query.ToList();

            var result = Mapper.Map<IList<Model.User>>(entities);

            return result;
        }

        public Model.User GetById(int id)
        {
            var entity = Context.Users.Find(id);

            return Mapper.Map<Model.User>(entity);
        }

        public Model.User Insert(UserUpsertRequest request)
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

        public Model.User Update(int id, UserUpsertRequest request)
        {
            var entity = Context.Users.Find(id);
            Mapper.Map(request, entity);

            Context.SaveChanges();
            return Mapper.Map<Model.User>(entity);
        }
    }
}
