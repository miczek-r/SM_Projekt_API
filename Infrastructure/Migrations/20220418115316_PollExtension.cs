using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class PollExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Polls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Polls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PollType",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PollId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PollId",
                table: "AspNetUsers",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Polls_PollId",
                table: "AspNetUsers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Polls_PollId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PollId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "PollType",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "AspNetUsers");
        }
    }
}
