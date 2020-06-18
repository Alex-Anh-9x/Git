using Microsoft.EntityFrameworkCore.Migrations;

namespace Pada.Migrations
{
    public partial class addPKPendingPhotoRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "Transaction ID",
                table: "PendingPhotoRequest",
                column: "TransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Transaction ID",
                table: "PendingPhotoRequest");
        }
    }
}
