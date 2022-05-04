using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Polls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ResultsArePublic",
                table: "Polls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Polls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PollId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PollId1",
                table: "AspNetUsers",
                column: "PollId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Polls_PollId1",
                table: "AspNetUsers",
                column: "PollId1",
                principalTable: "Polls",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Polls_PollId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PollId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "ResultsArePublic",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "PollId1",
                table: "AspNetUsers");
        }
    }
}
