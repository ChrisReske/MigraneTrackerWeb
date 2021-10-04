using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class ChangeIdPropertyNameinEntryPainType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryPainTypes_Entries_EntryId",
                table: "EntryPainTypes");

            migrationBuilder.DropColumn(
                name: "MainEntryId",
                table: "EntryPainTypes");

            migrationBuilder.AlterColumn<int>(
                name: "EntryId",
                table: "EntryPainTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryPainTypes_Entries_EntryId",
                table: "EntryPainTypes",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryPainTypes_Entries_EntryId",
                table: "EntryPainTypes");

            migrationBuilder.AlterColumn<int>(
                name: "EntryId",
                table: "EntryPainTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MainEntryId",
                table: "EntryPainTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryPainTypes_Entries_EntryId",
                table: "EntryPainTypes",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
