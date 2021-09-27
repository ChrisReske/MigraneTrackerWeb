using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddListOfWeatherDataToEntryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_WeatherData_WeatherDataId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_WeatherDataId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "WeatherDataId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "WeatherData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_EntryId",
                table: "WeatherData",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Entries_EntryId",
                table: "WeatherData",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Entries_EntryId",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherData_EntryId",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "WeatherData");

            migrationBuilder.AddColumn<int>(
                name: "WeatherDataId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_WeatherDataId",
                table: "Entries",
                column: "WeatherDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_WeatherData_WeatherDataId",
                table: "Entries",
                column: "WeatherDataId",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
