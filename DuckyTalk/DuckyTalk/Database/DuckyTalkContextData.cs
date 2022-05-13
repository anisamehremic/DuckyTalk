using Microsoft.EntityFrameworkCore;
using System;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class DuckyTalkContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.User()
            {
                UserId = 1,
                FirstName = "Anisa",
                LastName = "Mehremic",
                Username = "anisam",
                BirthDate =new DateTime(1998, 11, 4, 14, 28, 58, 693, DateTimeKind.Local),
                Email = "anisa.mehremic@edu.fit.ba",
                PasswordHash = "+WQk9mVupe+VOTeMI1a8PsyMmR0=",//anisa123
                PasswordSalt = "cPYUsauMRpahKHypOM3BIA==",
            });
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.User()
            {
                UserId = 2,
                FirstName = "Lejla",
                LastName = "Mujakic",
                Username = "lejlam",
                BirthDate = new DateTime(1998, 12, 21, 11, 55, 58, 693, DateTimeKind.Local),
                Email = "lejla.mujakic@edu.fit.ba",
                PasswordHash = "+WQk9mVupe+VOTeMI1a8PsyMmR0=",//anisa123
                PasswordSalt = "cPYUsauMRpahKHypOM3BIA==",
            });
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 1,
                Name = "NaN",
                Description = "",
                IsDeleted = false,
            });
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 2,
                Name = "SQL",
                Description = "SQL is a standard language for accessing and manipulating databases.",
                IsDeleted = false,
            });   
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 3,
                Name = ".Net",
                Description = ".NET is a free, cross-platform, open source developer platform for building many different types of applications. The .NET framework can work with several programming languages such as C#, VB.NET, C++ and F#. At Grand Circus, we use C#.",
                IsDeleted = false,
            });
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 1,
                Name = "Music",
                Description = "Rock music",
            });
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 2,
                Name = "Movies",
                Description = "Comedy",
            });  
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 1,
                UserId = 1,
                TechnologyId = 1,
                IsDeleted=false,
            });   
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 2,
                UserId = 2,
                TechnologyId = 1,
                IsDeleted=false,
            });  
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 3,
                UserId = 1,
                TechnologyId = 2,
                IsDeleted=false,
            });   
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 1,
                UserId = 1,
                InterestId = 1,
                IsActive = false,
            });     
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 2,
                UserId = 2,
                InterestId = 1,
                IsActive = true,
            });     
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 3,
                UserId = 1,
                InterestId = 2,
                IsActive = true,
            });    
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserMessage()
            {
                UserMessageId = 1,
                UserId = 1,
                MessageId = 1,
                TimeShowed = new DateTime(2022, 5, 12, 14, 28, 58, 693, DateTimeKind.Local),
            });    
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.UserMessage()
            {
                UserMessageId = 1,
                UserId = 2,
                MessageId = 2,
                TimeShowed = new DateTime(2022, 5, 12, 15, 28, 58, 693, DateTimeKind.Local),
            });  
           

            //modelBuilder.Entity<Message>().HasData(Helpers.LoadingDataHelper.LoadJsonFromFile<Message>("MessagesJson.json"));
        }
        
    }
}
