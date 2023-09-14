using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class UpdateDB100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "paymentMethod",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "paymentMethod",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "paymentMethod",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpiryDate",
                table: "paymentMethod",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpiId",
                table: "paymentMethod",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "paymentMethod");

            migrationBuilder.DropColumn(
                name: "CVV",
                table: "paymentMethod");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "paymentMethod");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "paymentMethod");

            migrationBuilder.DropColumn(
                name: "UpiId",
                table: "paymentMethod");
        }
    }
}
