using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class UpdateDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBirth",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "firstName",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fullName",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lastName",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "user");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "user");
        }
    }
}
