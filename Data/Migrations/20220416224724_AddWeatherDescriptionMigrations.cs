using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddWeatherDescriptionMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<float>(type: "real", nullable: false),
                    Min = table.Column<float>(type: "real", nullable: false),
                    Max = table.Column<float>(type: "real", nullable: false),
                    Night = table.Column<float>(type: "real", nullable: false),
                    Evening = table.Column<float>(type: "real", nullable: false),
                    Morning = table.Column<float>(type: "real", nullable: false),
                    Day_FeelsLike = table.Column<float>(type: "real", nullable: false),
                    Night_FeelsLike = table.Column<float>(type: "real", nullable: false),
                    Evening_FeelsLike = table.Column<float>(type: "real", nullable: false),
                    Morning_FeelsLike = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherAlert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherId = table.Column<int>(type: "int", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Event = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherAlert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherAlert_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherId = table.Column<int>(type: "int", nullable: false),
                    Main = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherDescription_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_WeatherId",
                table: "Temperature",
                column: "WeatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherAlert_WeatherId",
                table: "WeatherAlert",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDescription_WeatherId",
                table: "WeatherDescription",
                column: "WeatherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "WeatherAlert");

            migrationBuilder.DropTable(
                name: "WeatherDescription");
        }
    }
}
