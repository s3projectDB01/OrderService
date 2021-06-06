using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.OrderService.EntityFramework.Migrations
{
    public partial class AddBoolToSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Sessions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Sessions");
        }
    }
}
