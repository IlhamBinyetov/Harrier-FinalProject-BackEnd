using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrierFinalProject.Migrations
{
    public partial class CarTableAndAppUserTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AppUserId1",
                table: "Cars",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId1",
                table: "Cars",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AppUserId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Cars");
        }
    }
}
