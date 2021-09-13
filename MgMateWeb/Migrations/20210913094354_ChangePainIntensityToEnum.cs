using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class ChangePainIntensityToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_PainIntensities_PainIntensityId",
                table: "Entries");

            migrationBuilder.DropTable(
                name: "PainIntensities");

            migrationBuilder.DropIndex(
                name: "IX_Entries_PainIntensityId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "PainIntensityId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "PainIntensity",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PainIntensity",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "PainIntensityId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PainIntensities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainIntensities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PainIntensityId",
                table: "Entries",
                column: "PainIntensityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_PainIntensities_PainIntensityId",
                table: "Entries",
                column: "PainIntensityId",
                principalTable: "PainIntensities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
