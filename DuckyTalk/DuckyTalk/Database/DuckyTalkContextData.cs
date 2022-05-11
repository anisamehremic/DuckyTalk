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
            modelBuilder.Entity<Messages>().HasData(Helpers.LoadingDataHelper.LoadJsonFromFile<Messages>("MessagesJson.json"));
        }
        
    }
}
