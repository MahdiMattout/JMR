using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMR.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Hashedpassword = table.Column<string>(type: "TEXT", nullable: false),
                    passwordSalt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    minPay = table.Column<int>(type: "INTEGER", nullable: false),
                    maxPay = table.Column<int>(type: "INTEGER", nullable: false),
                    timeFrame = table.Column<int>(type: "INTEGER", nullable: false),
                    timeUnit = table.Column<string>(type: "TEXT", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostSkillIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    postId = table.Column<int>(type: "INTEGER", nullable: false),
                    skillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostSkillIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequiredSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    skillName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FName = table.Column<string>(type: "TEXT", nullable: false),
                    LName = table.Column<string>(type: "TEXT", nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CredentialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

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

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 5, "HTML" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 6, "Java" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 7, "Javascript" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Id", "skillName" },
                values: new object[] { 8, "CSS" });

            migrationBuilder.CreateIndex(
                name: "IX_credentials_Email",
                table: "credentials",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credentials");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostSkillIds");

            migrationBuilder.DropTable(
                name: "RequiredSkills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
