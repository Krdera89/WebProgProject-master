using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DODeath",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DOM",
                table: "Person");

            migrationBuilder.AddColumn<DateTime>(
                name: "AgeAtDeath",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfMarriage",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeAtDeath",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateOfMarriage",
                table: "Person");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DODeath",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DOM",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
