using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    public partial class AddPainIntensityToPainTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PainIntensity",
                table: "PainTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PainIntensity",
                table: "PainTypes");
        }
    }
}
