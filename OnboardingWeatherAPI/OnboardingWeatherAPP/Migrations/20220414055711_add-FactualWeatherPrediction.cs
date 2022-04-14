using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingWeatherAPI.Migrations
{
    public partial class addFactualWeatherPrediction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityForecaster_Cities_CityId",
                table: "CityForecaster");

            migrationBuilder.DropForeignKey(
                name: "FK_CityForecaster_Forecasters_ForecasterId",
                table: "CityForecaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityForecaster",
                table: "CityForecaster");

            migrationBuilder.RenameTable(
                name: "CityForecaster",
                newName: "CityForecasters");

            migrationBuilder.RenameIndex(
                name: "IX_CityForecaster_ForecasterId",
                table: "CityForecasters",
                newName: "IX_CityForecasters_ForecasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityForecasters",
                table: "CityForecasters",
                columns: new[] { "CityId", "ForecasterId" });

            migrationBuilder.CreateTable(
                name: "FactualPredictions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactualPredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactualPredictions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactualPredictions_CityId",
                table: "FactualPredictions",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityForecasters_Cities_CityId",
                table: "CityForecasters",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityForecasters_Forecasters_ForecasterId",
                table: "CityForecasters",
                column: "ForecasterId",
                principalTable: "Forecasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityForecasters_Cities_CityId",
                table: "CityForecasters");

            migrationBuilder.DropForeignKey(
                name: "FK_CityForecasters_Forecasters_ForecasterId",
                table: "CityForecasters");

            migrationBuilder.DropTable(
                name: "FactualPredictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityForecasters",
                table: "CityForecasters");

            migrationBuilder.RenameTable(
                name: "CityForecasters",
                newName: "CityForecaster");

            migrationBuilder.RenameIndex(
                name: "IX_CityForecasters_ForecasterId",
                table: "CityForecaster",
                newName: "IX_CityForecaster_ForecasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityForecaster",
                table: "CityForecaster",
                columns: new[] { "CityId", "ForecasterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CityForecaster_Cities_CityId",
                table: "CityForecaster",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityForecaster_Forecasters_ForecasterId",
                table: "CityForecaster",
                column: "ForecasterId",
                principalTable: "Forecasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
