using Microsoft.EntityFrameworkCore.Migrations;
using System;



namespace WebProgProject.Data.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOM",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Father",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mother",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Siblings",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spouse",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOM",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Father",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Mother",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Siblings",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Spouse",
                table: "Person");
        }
    }
}
