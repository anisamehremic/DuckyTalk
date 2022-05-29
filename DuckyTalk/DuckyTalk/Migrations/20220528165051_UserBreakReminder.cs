using Microsoft.EntityFrameworkCore.Migrations;

namespace DuckyTalk.Migrations
{
    public partial class UserBreakReminder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BreakNotificationsEnabled",
                table: "UserBreakReminder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EndTimeNotificationsEnabled",
                table: "UserBreakReminder",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakNotificationsEnabled",
                table: "UserBreakReminder");

            migrationBuilder.DropColumn(
                name: "EndTimeNotificationsEnabled",
                table: "UserBreakReminder");
        }
    }
}
