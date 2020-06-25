using Microsoft.EntityFrameworkCore.Migrations;

namespace Pada.Migrations.Pada_Authen
{
    public partial class UpdateUserInfoWithLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserLevel",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "AspNetUsers");
        }
    }
}
