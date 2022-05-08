using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMR.Migrations
{
    public partial class addedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 1, "Python" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 2, "C++" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 3, "SQL" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 4, "C#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RequiredSkills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequiredSkills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequiredSkills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequiredSkills",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
