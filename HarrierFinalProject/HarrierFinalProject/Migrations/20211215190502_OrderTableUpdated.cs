using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrierFinalProject.Migrations
{
    public partial class OrderTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CarStatuses_CarStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CarStatusId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CarStatusId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarStatusId",
                table: "Orders",
                column: "CarStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CarStatuses_CarStatusId",
                table: "Orders",
                column: "CarStatusId",
                principalTable: "CarStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
