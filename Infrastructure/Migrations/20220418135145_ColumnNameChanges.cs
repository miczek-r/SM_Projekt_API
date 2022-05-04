using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ColumnNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Questions",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Answers",
                newName: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Questions",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Answers",
                newName: "Value");
        }
    }
}
