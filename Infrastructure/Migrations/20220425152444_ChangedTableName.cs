using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionAnswers_Answers_AnswerId",
                table: "UserQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionAnswers_AspNetUsers_UserId",
                table: "UserQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionAnswers_Questions_QuestionId",
                table: "UserQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestionAnswers",
                table: "UserQuestionAnswers");

            migrationBuilder.RenameTable(
                name: "UserQuestionAnswers",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestionAnswers_UserId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestionAnswers_QuestionId",
                table: "Votes",
                newName: "IX_Votes_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestionAnswers_AnswerId",
                table: "Votes",
                newName: "IX_Votes_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Answers_AnswerId",
                table: "Votes",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Questions_QuestionId",
                table: "Votes",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Answers_AnswerId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Questions_QuestionId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "UserQuestionAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "UserQuestionAnswers",
                newName: "IX_UserQuestionAnswers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_QuestionId",
                table: "UserQuestionAnswers",
                newName: "IX_UserQuestionAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_AnswerId",
                table: "UserQuestionAnswers",
                newName: "IX_UserQuestionAnswers_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestionAnswers",
                table: "UserQuestionAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionAnswers_Answers_AnswerId",
                table: "UserQuestionAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionAnswers_AspNetUsers_UserId",
                table: "UserQuestionAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionAnswers_Questions_QuestionId",
                table: "UserQuestionAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
