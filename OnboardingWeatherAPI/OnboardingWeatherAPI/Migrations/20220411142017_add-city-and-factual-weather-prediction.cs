using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingWeatherAPI.Migrations
{
    public partial class addcityandfactualweatherprediction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactualWeatherPredictions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    WeatherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactualWeatherPredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactualWeatherPredictions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactualWeatherPredictions_CityId",
                table: "FactualWeatherPredictions",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactualWeatherPredictions");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
