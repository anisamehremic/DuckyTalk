using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DuckyTalk.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK__Messages__Techno__2B3F6F97",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBreakReminder",
                columns: table => new
                {
                    UserBreakReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    BreakNotificationsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    EndTimeNotificationsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBreakReminder", x => x.UserBreakReminderId);
                    table.ForeignKey(
                        name: "FK__UserBreak__UserI__3C69FB99",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInterest",
                columns: table => new
                {
                    UserInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterest", x => x.UserInterestId);
                    table.ForeignKey(
                        name: "FK__UserInter__Inter__33D4B598",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserInter__UserI__32E0915F",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTechnologies",
                columns: table => new
                {
                    UserTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTechnologies", x => x.UserTechnologyId);
                    table.ForeignKey(
                        name: "FK__UserTechn__Techn__2F10007B",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserTechn__UserI__2E1BDC42",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMessage",
                columns: table => new
                {
                    UserMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessage", x => x.UserMessageId);
                    table.ForeignKey(
                        name: "FK__UserMessa__Messa__38996AB5",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserMessa__UserI__37A5467C",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Inovations in tech world.", "Inovations" },
                    { 2, "Inovations in game development.", "Gaming" },
                    { 3, "Cyber secyurit, crypthography, data privacy", "Security" },
                    { 4, "Deep learning, machine learning, data analysis", "Data Science" },
                    { 5, "Robotics, bluetooth, iot", "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Description", "IsDeleted", "Keywords", "Name" },
                values: new object[,]
                {
                    { 9, "Python is a high-level general-purpose programming language.", false, null, "Python" },
                    { 8, "Angular is a development platform, built on TypeScript", false, null, "Angular" },
                    { 7, "Java Script is an object-oriented computer programming language commonly used to create interactive effects within web browsers.", false, null, "Java Script" },
                    { 6, "PHP is a widely-used open source general-purpose scripting language that is especially suited for web development and can be embedded into HTML.", false, null, "PHP" },
                    { 4, "C# is an object-oriented programming language from Microsoft.", false, null, "C#" },
                    { 3, "Java is an object-oriented programming language that produces software for multiple platforms.", false, null, "Java" },
                    { 2, "SQL is a standard language for accessing and manipulating databases.", false, null, "SQL" },
                    { 1, "", false, null, "NaN" },
                    { 5, "C++ is a general-purpose programming language which is an extension of the C programming language.", false, null, "C++" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "PasswordSalt", "Photo", "Username" },
                values: new object[,]
                {
                    { 3, new DateTime(1998, 6, 2, 11, 55, 58, 693, DateTimeKind.Local), "ilma.kazazic@edu.fit.ba", "Ilma", null, "Kazazić", "+WQk9mVupe+VOTeMI1a8PsyMmR0=", "cPYUsauMRpahKHypOM3BIA==", null, "ilmak" },
                    { 1, new DateTime(1998, 11, 4, 14, 28, 58, 693, DateTimeKind.Local), "anisa.mehremic@edu.fit.ba", "Anisa", null, "Mehremic", "+WQk9mVupe+VOTeMI1a8PsyMmR0=", "cPYUsauMRpahKHypOM3BIA==", null, "anisam" },
                    { 2, new DateTime(1998, 12, 21, 11, 55, 58, 693, DateTimeKind.Local), "lejla.mujakic@edu.fit.ba", "Lejla", null, "Mujakic", "+WQk9mVupe+VOTeMI1a8PsyMmR0=", "cPYUsauMRpahKHypOM3BIA==", null, "lejlam" },
                    { 4, new DateTime(1990, 7, 5, 5, 35, 58, 693, DateTimeKind.Local), "amel.music@edu.fit.ba", "Amel", null, "Musić", "+WQk9mVupe+VOTeMI1a8PsyMmR0=", "cPYUsauMRpahKHypOM3BIA==", null, "amelm" }
                });

            migrationBuilder.InsertData(
                table: "UserBreakReminder",
                columns: new[] { "UserBreakReminderId", "BreakNotificationsEnabled", "EndTime", "EndTimeNotificationsEnabled", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 1, 6, 16, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 1, 6, 8, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, true, new DateTime(2022, 1, 6, 17, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 1, 6, 9, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 4, false, new DateTime(2022, 1, 6, 16, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 1, 6, 8, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 2, false, new DateTime(2022, 1, 6, 15, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 1, 6, 7, 0, 0, 0, DateTimeKind.Local), 2 }
                });

            migrationBuilder.InsertData(
                table: "UserInterest",
                columns: new[] { "UserInterestId", "InterestId", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 3, 2, false, 3 },
                    { 9, 1, false, 2 },
                    { 7, 5, false, 2 },
                    { 8, 5, false, 3 },
                    { 2, 2, false, 2 },
                    { 6, 3, false, 4 },
                    { 10, 5, false, 1 },
                    { 5, 3, false, 1 },
                    { 1, 4, false, 1 },
                    { 4, 1, false, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserTechnologies",
                columns: new[] { "UserTechnologyId", "IsDeleted", "TechnologyId", "UserId" },
                values: new object[,]
                {
                    { 5, false, 1, 4 },
                    { 6, false, 5, 4 },
                    { 15, false, 7, 3 },
                    { 10, false, 9, 3 },
                    { 7, false, 6, 3 },
                    { 11, false, 8, 2 },
                    { 12, false, 7, 4 },
                    { 3, false, 7, 2 },
                    { 2, false, 2, 2 },
                    { 13, false, 5, 1 },
                    { 9, false, 8, 1 },
                    { 8, false, 7, 1 },
                    { 1, false, 1, 1 },
                    { 4, false, 3, 3 },
                    { 14, false, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TechnologyId",
                table: "Messages",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBreakReminder_UserId",
                table: "UserBreakReminder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_InterestId",
                table: "UserInterest",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_UserId",
                table: "UserInterest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_MessageId",
                table: "UserMessage",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_UserId",
                table: "UserMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechnologies_TechnologyId",
                table: "UserTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechnologies_UserId",
                table: "UserTechnologies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBreakReminder");

            migrationBuilder.DropTable(
                name: "UserInterest");

            migrationBuilder.DropTable(
                name: "UserMessage");

            migrationBuilder.DropTable(
                name: "UserTechnologies");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
