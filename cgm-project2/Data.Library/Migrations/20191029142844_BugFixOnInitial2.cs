using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Library.Migrations
{
    public partial class BugFixOnInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionString",
                table: "Question",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(0)",
                oldMaxLength: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionString",
                table: "Question",
                type: "character varying(0)",
                maxLength: 0,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
