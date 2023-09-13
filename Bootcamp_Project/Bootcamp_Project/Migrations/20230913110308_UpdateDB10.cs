using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_Project.Migrations
{
    public partial class UpdateDB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_Email",
                table: "user");
        }
    }
}
