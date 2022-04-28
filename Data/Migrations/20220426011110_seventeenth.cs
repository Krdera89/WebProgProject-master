using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class seventeenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Baptism",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCert",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChurchBuriedFrom",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeathCert",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Godparents",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Military",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Obituary",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidenceAtDeath",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Will",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Baptism",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BirthCert",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ChurchBuriedFrom",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DeathCert",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Godparents",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Military",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Obituary",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ResidenceAtDeath",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Will",
                table: "Person");
        }
    }
}
