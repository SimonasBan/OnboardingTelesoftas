using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingWeatherAPI.Migrations
{
    public partial class adddbseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Kaunas" },
                    { 2L, "Vilnius" },
                    { 3L, "Klaipėda" }
                });

            migrationBuilder.InsertData(
                table: "Forecasters",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "OpenWeatherMap" });

            migrationBuilder.InsertData(
                table: "FactualWeatherPredictions",
                columns: new[] { "Id", "CityId", "Date", "ForecasterId", "Temperature" },
                values: new object[] { 1L, 1L, new DateTime(2022, 4, 12, 16, 20, 5, 47, DateTimeKind.Local).AddTicks(1450), 1L, 12.5 });

            migrationBuilder.InsertData(
                table: "FactualWeatherPredictions",
                columns: new[] { "Id", "CityId", "Date", "ForecasterId", "Temperature" },
                values: new object[] { 2L, 1L, new DateTime(2022, 4, 11, 16, 20, 5, 47, DateTimeKind.Local).AddTicks(1481), 1L, 11.199999999999999 });

            migrationBuilder.InsertData(
                table: "FactualWeatherPredictions",
                columns: new[] { "Id", "CityId", "Date", "ForecasterId", "Temperature" },
                values: new object[] { 3L, 2L, new DateTime(2022, 4, 12, 16, 20, 5, 47, DateTimeKind.Local).AddTicks(1484), 1L, 10.199999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Forecasters",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
