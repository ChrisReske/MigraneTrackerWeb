using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class ChangeDataTypeOfEntryPropertiesReferringToDurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationOfActivity",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "DurationOfIncapacitation",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "PainDuration",
                table: "Entries");

            migrationBuilder.AddColumn<float>(
                name: "HoursOfActivity",
                table: "Entries",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HoursOfIncapacitation",
                table: "Entries",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HoursOfPain",
                table: "Entries",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursOfActivity",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "HoursOfIncapacitation",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "HoursOfPain",
                table: "Entries");

            migrationBuilder.AddColumn<DateTime>(
                name: "DurationOfActivity",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DurationOfIncapacitation",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PainDuration",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
