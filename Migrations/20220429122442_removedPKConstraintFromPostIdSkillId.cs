using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMR.Migrations
{
    public partial class removedPKConstraintFromPostIdSkillId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostSkillIds",
                table: "PostSkillIds");

            migrationBuilder.AlterColumn<string>(
                name: "skillName",
                table: "RequiredSkills",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "PostSkillIds",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "skillName",
                table: "RequiredSkills",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "PostSkillIds",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostSkillIds",
                table: "PostSkillIds",
                column: "postId");
        }
    }
}
