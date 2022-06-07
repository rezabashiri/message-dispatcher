using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Message.Dispatcher.Infrastructure.Migrations
{
    public partial class AddAppKeytoevententity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppKey",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppKey",
                table: "Events");
        }
    }
}
