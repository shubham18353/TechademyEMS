using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechademyEMS.Migrations
{
    public partial class initail6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "AspNetUsers",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "ConfirmPassword");
        }
    }
}
