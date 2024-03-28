using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOptions_Questions_Question_ID",
                table: "QuestionOptions");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOptions_Questions_Question_ID",
                table: "QuestionOptions",
                column: "Question_ID",
                principalTable: "Questions",
                principalColumn: "Question_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOptions_Questions_Question_ID",
                table: "QuestionOptions");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOptions_Questions_Question_ID",
                table: "QuestionOptions",
                column: "Question_ID",
                principalTable: "Questions",
                principalColumn: "Question_ID");
        }
    }
}
