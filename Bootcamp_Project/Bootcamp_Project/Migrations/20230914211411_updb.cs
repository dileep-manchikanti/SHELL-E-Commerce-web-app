using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class updb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_address_addressId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_addressId",
                table: "order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_order_addressId",
                table: "order",
                column: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_address_addressId",
                table: "order",
                column: "addressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
