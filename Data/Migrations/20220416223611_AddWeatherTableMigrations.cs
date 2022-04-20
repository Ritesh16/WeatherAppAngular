using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddWeatherTableMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    WeatherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sunrise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sunset = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Moonrise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Moonset = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoonPhase = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    DewPoint = table.Column<float>(type: "real", nullable: false),
                    WindSpeed = table.Column<float>(type: "real", nullable: false),
                    WindDeg = table.Column<float>(type: "real", nullable: false),
                    WindGust = table.Column<float>(type: "real", nullable: false),
                    Clouds = table.Column<float>(type: "real", nullable: false),
                    Pop = table.Column<float>(type: "real", nullable: false),
                    UVI = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CityId",
                table: "Weather",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
