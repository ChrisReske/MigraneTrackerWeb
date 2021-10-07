using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddJunctionTableForEntryAndAccompanyingSymptom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalTable: "AccompanyingSymptoms",
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
        }
    }
}
