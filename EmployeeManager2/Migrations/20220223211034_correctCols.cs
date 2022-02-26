using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager2.Migrations
{
    public partial class correctCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Accountants");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Accountants");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Accountants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Accountants");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Accountants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Accountants",
                type: "datetime2",
                nullable: true);
        }
    }
}
