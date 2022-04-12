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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Forecasters",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
