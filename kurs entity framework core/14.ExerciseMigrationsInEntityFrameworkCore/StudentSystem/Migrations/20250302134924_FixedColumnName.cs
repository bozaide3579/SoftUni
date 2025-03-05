using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem.Migrations
{
    public partial class FixedColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type1",
                table: "Recources",
                newName: "RecourceType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Recources",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Recources",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "RecourceType",
                table: "Recources",
                newName: "Type1");
        }
    }
}
