using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class AddedProductTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "user_address",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "is_default",
                table: "user_address",
                newName: "isDefault");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "user_address",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "user",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "user",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "Phone_Number",
                table: "user",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "address",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "address",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "address",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "address_line_2",
                table: "address",
                newName: "addressLine2");

            migrationBuilder.RenameColumn(
                name: "address_line_1",
                table: "address",
                newName: "addressLine1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "user_address",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "isDefault",
                table: "user_address",
                newName: "is_default");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "user_address",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "user",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "user",
                newName: "Phone_Number");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "user",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "address",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "address",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "address",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "addressLine2",
                table: "address",
                newName: "address_line_2");

            migrationBuilder.RenameColumn(
                name: "addressLine1",
                table: "address",
                newName: "address_line_1");
        }
    }
}
