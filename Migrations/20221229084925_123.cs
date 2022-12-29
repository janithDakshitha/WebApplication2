using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Class");

            migrationBuilder.AddColumn<string>(
                name: "UniFullname",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uniname",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniFullname",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Uniname",
                table: "Class");

            migrationBuilder.AddColumn<int>(
                name: "name",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
