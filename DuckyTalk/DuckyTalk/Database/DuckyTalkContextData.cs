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
                  modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.User()
                  {
                      UserId = 3,
                      FirstName = "Ilma",
                      LastName = "Kazazić",
                      Username = "ilmak",
                      BirthDate = new DateTime(1998, 6, 2, 11, 55, 58, 693, DateTimeKind.Local),
                      Email = "ilma.kazazic@edu.fit.ba",
                      PasswordHash = "+WQk9mVupe+VOTeMI1a8PsyMmR0=",//anisa123
                      PasswordSalt = "cPYUsauMRpahKHypOM3BIA==",
                  });
            modelBuilder.Entity<User>().HasData(new DuckyTalk.Database.User()
            {
                UserId = 4,
                FirstName = "Amel",
                LastName = "Musić",
                Username = "amelm",
                BirthDate = new DateTime(1990, 7, 5, 5, 35, 58, 693, DateTimeKind.Local),
                Email = "amel.music@edu.fit.ba",
                PasswordHash = "+WQk9mVupe+VOTeMI1a8PsyMmR0=",//anisa123
                PasswordSalt = "cPYUsauMRpahKHypOM3BIA==",
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 1,
                Name = "NaN",
                Description = "",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 2,
                Name = "SQL",
                Description = "SQL is a standard language for accessing and manipulating databases.",
                IsDeleted = false,
            });   
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 3,
                Name = "Java",
                Description = "Java is an object-oriented programming language that produces software for multiple platforms.",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 4,
                Name = "C#",
                Description = "C# is an object-oriented programming language from Microsoft.",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 5,
                Name = "C++",
                Description = "C++ is a general-purpose programming language which is an extension of the C programming language.",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 6,
                Name = "PHP",
                Description = "PHP is a widely-used open source general-purpose scripting language that is especially suited for web development and can be embedded into HTML.",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 7,
                Name = "Java Script",
                Description = "Java Script is an object-oriented computer programming language commonly used to create interactive effects within web browsers.",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 8,
                Name = "Angular",
                Description = "Angular is a development platform, built on TypeScript",
                IsDeleted = false,
            });
            modelBuilder.Entity<Technology>().HasData(new DuckyTalk.Database.Technology()
            {
                TechnologyId = 9,
                Name = "Python",
                Description = "Python is a high-level general-purpose programming language.",
                IsDeleted = false,
            });
            modelBuilder.Entity<Interest>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 1,
                Name = "Inovations",
                Description = "Inovations in tech world.",
            });
            modelBuilder.Entity<Interest>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 2,
                Name = "Gaming",
                Description = "Inovations in game development.",
            });
            modelBuilder.Entity<Interest>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 3,
                Name = "Security",
                Description = "Cyber secyurit, crypthography, data privacy",
            });
            modelBuilder.Entity<Interest>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 4,
                Name = "Data Science",
                Description = "Deep learning, machine learning, data analysis",
            });
            modelBuilder.Entity<Interest>().HasData(new DuckyTalk.Database.Interest()
            {
                InterestId = 5,
                Name = "Hardware",
                Description = "Robotics, bluetooth, iot",
            });
         
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 1,
                UserId = 1,
                TechnologyId = 1,
                IsDeleted=false,
            });   
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 2,
                UserId = 2,
                TechnologyId = 2,
                IsDeleted=false,
            });  
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 3,
                UserId = 2,
                TechnologyId = 7,
                IsDeleted=false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 4,
                UserId = 3,
                TechnologyId = 3,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 5,
                UserId = 4,
                TechnologyId = 1,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 6,
                UserId = 4,
                TechnologyId = 5,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 7,
                UserId = 3,
                TechnologyId = 6,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 8,
                UserId = 1,
                TechnologyId = 7,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 9,
                UserId = 1,
                TechnologyId = 8,
                IsDeleted = false,
            }); 
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 10,
                UserId = 3,
                TechnologyId = 9,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 11,
                UserId = 2,
                TechnologyId = 8,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 12,
                UserId = 4,
                TechnologyId = 7,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 13,
                UserId = 1,
                TechnologyId = 5,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 14,
                UserId = 4,
                TechnologyId = 4,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserTechnology>().HasData(new DuckyTalk.Database.UserTechnology()
            {
                UserTechnologyId = 15,
                UserId = 3,
                TechnologyId = 7,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserBreakReminder>().HasData(new DuckyTalk.Database.UserBreakReminder()
            {
                UserBreakReminderId = 1,
                UserId = 1,
                StartTime = new DateTime(2022, 1, 6, 08, 00, 00, 000, DateTimeKind.Local),
                EndTime = new DateTime(2022, 1, 6, 16, 00, 00, 000, DateTimeKind.Local),
                BreakNotificationsEnabled = true,
                EndTimeNotificationsEnabled = false,
            });
            modelBuilder.Entity<UserBreakReminder>().HasData(new DuckyTalk.Database.UserBreakReminder()
            {
                UserBreakReminderId = 2,
                UserId = 2,
                StartTime = new DateTime(2022, 1, 6, 07, 00, 00, 000, DateTimeKind.Local),
                EndTime = new DateTime(2022, 1, 6, 15, 00, 00, 000, DateTimeKind.Local),
                BreakNotificationsEnabled = false,
                EndTimeNotificationsEnabled = true,
            });
            modelBuilder.Entity<UserBreakReminder>().HasData(new DuckyTalk.Database.UserBreakReminder()
            {
                UserBreakReminderId = 3,
                UserId = 3,
                StartTime = new DateTime(2022, 1, 6, 09, 00, 00, 000, DateTimeKind.Local),
                EndTime = new DateTime(2022, 1, 6, 17, 00, 00, 000, DateTimeKind.Local),
                BreakNotificationsEnabled = true,
                EndTimeNotificationsEnabled = true,
            });
            modelBuilder.Entity<UserBreakReminder>().HasData(new DuckyTalk.Database.UserBreakReminder()
            {
                UserBreakReminderId = 4,
                UserId = 4,
                StartTime = new DateTime(2022, 1, 6, 08, 00, 00, 000, DateTimeKind.Local),
                EndTime = new DateTime(2022, 1, 6, 16, 00, 00, 000, DateTimeKind.Local),
                BreakNotificationsEnabled = false,
                EndTimeNotificationsEnabled = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 1,
                UserId = 1,
                InterestId = 4,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 2,
                UserId = 2,
                InterestId = 2,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 3,
                UserId = 3,
                InterestId = 2,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 4,
                UserId = 4,
                InterestId = 1,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 5,
                UserId = 1,
                InterestId = 3,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 6,
                UserId = 4,
                InterestId = 3,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 7,
                UserId = 2,
                InterestId = 5,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 8,
                UserId = 3,
                InterestId = 5,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 9,
                UserId = 2,
                InterestId = 1,
                IsDeleted = false,
            });
            modelBuilder.Entity<UserInterest>().HasData(new DuckyTalk.Database.UserInterest()
            {
                UserInterestId = 10,
                UserId = 1,
                InterestId = 5,
                IsDeleted = false,
            });
         
            //modelBuilder.Entity<Message>().HasData(Helpers.LoadingDataHelper.LoadJsonFromFile<Message>("MessagesJson.json"));
        }
        
    }
}
