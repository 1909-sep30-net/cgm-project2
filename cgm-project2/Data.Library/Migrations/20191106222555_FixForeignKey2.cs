using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Library.Migrations
{
    public partial class FixForeignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Title_TakerId",
                table: "Result");

            migrationBuilder.CreateIndex(
                name: "IX_Result_TitleId",
                table: "Result",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Title_TitleId",
                table: "Result",
                column: "TitleId",
                principalTable: "Title",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Title_TitleId",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_TitleId",
                table: "Result");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Title_TakerId",
                table: "Result",
                column: "TakerId",
                principalTable: "Title",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
