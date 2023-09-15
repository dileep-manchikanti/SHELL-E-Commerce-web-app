using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class inddb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItem_cart_cartId",
                table: "cartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItem_product_productId",
                table: "cartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_order_orderId",
                table: "orderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_product_productId",
                table: "orderItem");

            migrationBuilder.DropIndex(
                name: "IX_orderItem_orderId",
                table: "orderItem");

            migrationBuilder.DropIndex(
                name: "IX_orderItem_productId",
                table: "orderItem");

            migrationBuilder.DropIndex(
                name: "IX_cartItem_cartId",
                table: "cartItem");

            migrationBuilder.DropIndex(
                name: "IX_cartItem_productId",
                table: "cartItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderItem_orderId",
                table: "orderItem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_productId",
                table: "orderItem",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItem_cartId",
                table: "cartItem",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItem_productId",
                table: "cartItem",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItem_cart_cartId",
                table: "cartItem",
                column: "cartId",
                principalTable: "cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItem_product_productId",
                table: "cartItem",
                column: "productId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_order_orderId",
                table: "orderItem",
                column: "orderId",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_product_productId",
                table: "orderItem",
                column: "productId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
