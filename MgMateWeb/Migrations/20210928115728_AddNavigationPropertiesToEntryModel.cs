using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddNavigationPropertiesToEntryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccompanyingSymptoms_Entries_EntryId",
                table: "AccompanyingSymptoms");

            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Entries_EntryId",
                table: "Medications");

            migrationBuilder.DropForeignKey(
                name: "FK_PainTypes_Entries_EntryId",
                table: "PainTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Triggers_Entries_EntryId",
                table: "Triggers");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Entries_EntryId",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherData_EntryId",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_Triggers_EntryId",
                table: "Triggers");

            migrationBuilder.DropIndex(
                name: "IX_PainTypes_EntryId",
                table: "PainTypes");

            migrationBuilder.DropIndex(
                name: "IX_Medications_EntryId",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_AccompanyingSymptoms_EntryId",
                table: "AccompanyingSymptoms");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Triggers");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "PainTypes");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "AccompanyingSymptoms");

            migrationBuilder.AddColumn<int>(
                name: "AccompanyingSymptomId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicationId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PainTypeId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TriggerId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeatherDataId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AccompanyingSymptomId",
                table: "Entries",
                column: "AccompanyingSymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_MedicationId",
                table: "Entries",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PainTypeId",
                table: "Entries",
                column: "PainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TriggerId",
                table: "Entries",
                column: "TriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_WeatherDataId",
                table: "Entries",
                column: "WeatherDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AccompanyingSymptoms_AccompanyingSymptomId",
                table: "Entries",
                column: "AccompanyingSymptomId",
                principalTable: "AccompanyingSymptoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Medications_MedicationId",
                table: "Entries",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_PainTypes_PainTypeId",
                table: "Entries",
                column: "PainTypeId",
                principalTable: "PainTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Triggers_TriggerId",
                table: "Entries",
                column: "TriggerId",
                principalTable: "Triggers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_WeatherData_WeatherDataId",
                table: "Entries",
                column: "WeatherDataId",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AccompanyingSymptoms_AccompanyingSymptomId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Medications_MedicationId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_PainTypes_PainTypeId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Triggers_TriggerId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_WeatherData_WeatherDataId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_AccompanyingSymptomId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_MedicationId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_PainTypeId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_TriggerId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_WeatherDataId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "AccompanyingSymptomId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "MedicationId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "PainTypeId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TriggerId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "WeatherDataId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "WeatherData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "Triggers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "PainTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "Medications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "AccompanyingSymptoms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_EntryId",
                table: "WeatherData",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_EntryId",
                table: "Triggers",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_PainTypes_EntryId",
                table: "PainTypes",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_EntryId",
                table: "Medications",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccompanyingSymptoms_EntryId",
                table: "AccompanyingSymptoms",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccompanyingSymptoms_Entries_EntryId",
                table: "AccompanyingSymptoms",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Entries_EntryId",
                table: "Medications",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PainTypes_Entries_EntryId",
                table: "PainTypes",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Triggers_Entries_EntryId",
                table: "Triggers",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Entries_EntryId",
                table: "WeatherData",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
