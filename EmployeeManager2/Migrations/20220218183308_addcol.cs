using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager2.Migrations
{
    public partial class addcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientNumber",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientNumber",
                table: "Employee");
        }
    }
}
