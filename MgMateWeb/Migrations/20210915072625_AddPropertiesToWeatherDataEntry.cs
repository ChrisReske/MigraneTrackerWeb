using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddPropertiesToWeatherDataEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "WeatherData",
                newName: "CountryCode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "WeatherData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Humidity",
                table: "WeatherData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pressure",
                table: "WeatherData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Temperature",
                table: "WeatherData",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "WeatherData");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "WeatherData",
                newName: "Description");
        }
    }
}
