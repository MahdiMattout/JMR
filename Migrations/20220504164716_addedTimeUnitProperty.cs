using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMR.Migrations
{
    public partial class addedTimeUnitProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "timeUnit",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeUnit",
                table: "Posts");
        }
    }
}
