using Microsoft.EntityFrameworkCore.Migrations;

namespace Pada.Migrations
{
    public partial class UpdateImageURL3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "PendingPhotoRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "PendingPhotoRequest",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
