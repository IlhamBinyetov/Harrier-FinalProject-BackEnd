using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrierFinalProject.Migrations
{
    public partial class SLiderTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image" },
                values: new object[] { 1, "slider-1.jpg" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Image" },
                values: new object[] { 2, "slider-2.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
