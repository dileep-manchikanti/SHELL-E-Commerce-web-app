using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "product",
                newName: "basePrice");

            migrationBuilder.AlterColumn<string>(
                name: "productImage",
                table: "product",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<float>(
                name: "cgst",
                table: "product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sgst",
                table: "product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "paymentType",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<float>(
                name: "rating",
                table: "feedback",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "feedback",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GlobalVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalVariables", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalVariables");

            migrationBuilder.DropColumn(
                name: "cgst",
                table: "product");

            migrationBuilder.DropColumn(
                name: "sgst",
                table: "product");

            migrationBuilder.DropColumn(
                name: "image",
                table: "paymentType");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "feedback");

            migrationBuilder.RenameColumn(
                name: "basePrice",
                table: "product",
                newName: "price");

            migrationBuilder.AlterColumn<string>(
                name: "productImage",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rating",
                table: "feedback",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
