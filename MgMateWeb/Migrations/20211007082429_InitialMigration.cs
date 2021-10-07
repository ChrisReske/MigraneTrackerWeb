using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursOfPain = table.Column<float>(type: "real", nullable: false),
                    WasPainIncreasedDuringPhysicalActivity = table.Column<bool>(type: "bit", nullable: false),
                    HoursOfIncapacitation = table.Column<float>(type: "real", nullable: false),
                    HoursOfActivity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccompanyingSymptom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccompanyingSymptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccompanyingSymptoms_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryAccompanyingSymptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    AccompanyingSymptomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryAccompanyingSymptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryAccompanyingSymptoms_AccompanyingSymptoms_AccompanyingSymptomId",
                        column: x => x.AccompanyingSymptomId,
                        principalTable: "AccompanyingSymptom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryAccompanyingSymptoms_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccompanyingSymptoms_EntryId",
                table: "AccompanyingSymptom",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryAccompanyingSymptoms_AccompanyingSymptomId",
                table: "EntryAccompanyingSymptoms",
                column: "AccompanyingSymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryAccompanyingSymptoms_EntryId",
                table: "EntryAccompanyingSymptoms",
                column: "EntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryAccompanyingSymptoms");

            migrationBuilder.DropTable(
                name: "AccompanyingSymptom");

            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
