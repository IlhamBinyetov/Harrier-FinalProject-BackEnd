using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrierFinalProject.Migrations
{
    public partial class CarTableUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AppUserId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AppUserId",
                table: "Cars",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId",
                table: "Cars",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_AppUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AppUserId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Cars",
                type: "nvarchar(450)",
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
    }
}
