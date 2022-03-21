using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class Eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BurialDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GrandFather",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrandMother",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GreatGrandFather",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GreatGrandMother",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurialDate",
                table: "Person");

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
        }
    }
}
