using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingWeatherAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityForecaster",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    ForecasterId = table.Column<long>(type: "bigint", nullable: false),
                    AcceessItem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityForecaster", x => new { x.CityId, x.ForecasterId });
                    table.ForeignKey(
                        name: "FK_CityForecaster_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityForecaster_Forecasters_ForecasterId",
                        column: x => x.ForecasterId,
                        principalTable: "Forecasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityForecaster_ForecasterId",
                table: "CityForecaster",
                column: "ForecasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityForecaster");

            migrationBuilder.DropTable(
                name: "Forecasters");
        }
    }
}
