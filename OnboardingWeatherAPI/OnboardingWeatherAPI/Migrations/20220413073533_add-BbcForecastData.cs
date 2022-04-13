using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingWeatherAPI.Migrations
{
    public partial class addBbcForecastData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BbcForecasterData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RssCode = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbcForecasterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbcForecasterData_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4L, "Tbilisi" });

            migrationBuilder.UpdateData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 4, 13, 10, 35, 33, 190, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 4, 12, 10, 35, 33, 190, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2022, 4, 13, 10, 35, 33, 190, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.InsertData(
                table: "BbcForecasterData",
                columns: new[] { "Id", "CityId", "RssCode" },
                values: new object[] { 1L, 4L, 611717L });

            migrationBuilder.CreateIndex(
                name: "IX_BbcForecasterData_CityId",
                table: "BbcForecasterData",
                column: "CityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BbcForecasterData");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 4, 12, 16, 20, 5, 47, DateTimeKind.Local).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 4, 11, 16, 20, 5, 47, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "FactualWeatherPredictions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2022, 4, 12, 16, 20, 5, 47, DateTimeKind.Local).AddTicks(1484));
        }
    }
}
