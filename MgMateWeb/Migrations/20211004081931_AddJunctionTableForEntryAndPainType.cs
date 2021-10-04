using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddJunctionTableForEntryAndPainType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryPainTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PainTypeId = table.Column<int>(type: "int", nullable: false),
                    MainEntryId = table.Column<int>(type: "int", nullable: false),
                    EntryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryPainTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryPainTypes_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryPainTypes_PainTypes_PainTypeId",
                        column: x => x.PainTypeId,
                        principalTable: "PainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryPainTypes_EntryId",
                table: "EntryPainTypes",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryPainTypes_PainTypeId",
                table: "EntryPainTypes",
                column: "PainTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryPainTypes");
        }
    }
}
