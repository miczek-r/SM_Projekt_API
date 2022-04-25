using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangedVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestionAnswers",
                table: "UserQuestionAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "UserQuestionAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "UserQuestionAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserQuestionAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserQuestionAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestionAnswers",
                table: "UserQuestionAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionAnswers_UserId",
                table: "UserQuestionAnswers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestionAnswers",
                table: "UserQuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestionAnswers_UserId",
                table: "UserQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserQuestionAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserQuestionAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "UserQuestionAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "UserQuestionAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestionAnswers",
                table: "UserQuestionAnswers",
                columns: new[] { "UserId", "QuestionId", "AnswerId" });
        }
    }
}
