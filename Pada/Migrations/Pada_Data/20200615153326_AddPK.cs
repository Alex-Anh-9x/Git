using Microsoft.EntityFrameworkCore.Migrations;

namespace Pada.Migrations
{
    public partial class AddPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "Email",
                table: "UserTable",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Email",
                table: "UserTable");
        }
    }
}
