using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddJunctionTableEntryAccompanyingSymptomPropertyToEntryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccompanyingSymptoms_Entries_EntryId",
                table: "AccompanyingSymptom");

            migrationBuilder.DropIndex(
                name: "IX_AccompanyingSymptoms_EntryId",
                table: "AccompanyingSymptom");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "AccompanyingSymptom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "AccompanyingSymptom",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccompanyingSymptoms_EntryId",
                table: "AccompanyingSymptom",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccompanyingSymptoms_Entries_EntryId",
                table: "AccompanyingSymptom",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
