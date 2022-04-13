using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class sixteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BPOF",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPOM",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuneralHome",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TombstoneInscription",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BPOF",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BPOM",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "FuneralHome",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "TombstoneInscription",
                table: "Person");
        }
    }
}
