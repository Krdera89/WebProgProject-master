using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class fourteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrandFather",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GrandMother",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GreatGrandFather",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GreatGrandMother",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "BurialYear",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CensusBookNumber",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CensusEntryNumber",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CensusPageNumber",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPSGravesite",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraveNumInCrypt",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmigrationYear",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotNumber",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatGma",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatGpa",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatGreatGma",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatGreatGpa",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MausCorridor",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MausTier",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrientationInLot",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatGma",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatGpa",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatGreatGma",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatGreatGpa",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionNum",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurialYear",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CensusBookNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CensusEntryNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CensusPageNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GPSGravesite",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "GraveNumInCrypt",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ImmigrationYear",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LotNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MatGma",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MatGpa",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MatGreatGma",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MatGreatGpa",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MausCorridor",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MausTier",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "OrientationInLot",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PatGma",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PatGpa",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PatGreatGma",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PatGreatGpa",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SectionNum",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "GrandFather",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrandMother",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GreatGrandFather",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GreatGrandMother",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
