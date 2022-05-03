using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Polls_PollId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Polls_PollId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Polls_PollId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PollId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PollId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PollId1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PollId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PollAllowed",
                columns: table => new
                {
                    PollId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollAllowed", x => new { x.UserId, x.PollId });
                    table.ForeignKey(
                        name: "FK_PollAllowed_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollAllowed_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollModerators",
                columns: table => new
                {
                    PollId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollModerators", x => new { x.UserId, x.PollId });
                    table.ForeignKey(
                        name: "FK_PollModerators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollModerators_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollAllowed_PollId",
                table: "PollAllowed",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollModerators_PollId",
                table: "PollModerators",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Polls_PollId",
                table: "Questions",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Polls_PollId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "PollAllowed");

            migrationBuilder.DropTable(
                name: "PollModerators");

            migrationBuilder.AlterColumn<int>(
                name: "PollId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PollId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PollId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PollId",
                table: "AspNetUsers",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PollId1",
                table: "AspNetUsers",
                column: "PollId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Polls_PollId",
                table: "AspNetUsers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Polls_PollId1",
                table: "AspNetUsers",
                column: "PollId1",
                principalTable: "Polls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Polls_PollId",
                table: "Questions",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");
        }
    }
}
