using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerLines_Questions_Question_ID",
                table: "AnswerLines");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerLines_Questions_Question_ID",
                table: "AnswerLines",
                column: "Question_ID",
                principalTable: "Questions",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerLines_Questions_Question_ID",
                table: "AnswerLines");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerLines_Questions_Question_ID",
                table: "AnswerLines",
                column: "Question_ID",
                principalTable: "Questions",
                principalColumn: "Question_ID");
        }
    }
}
