using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Person",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "profession",
                table: "Person",
                newName: "Profession");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "Person",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Person",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "job",
                table: "Person",
                newName: "Job");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Person",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "deathPlace",
                table: "Person",
                newName: "DeathPlace");

            migrationBuilder.RenameColumn(
                name: "deathCause",
                table: "Person",
                newName: "DeathCause");

            migrationBuilder.RenameColumn(
                name: "birthPlace",
                table: "Person",
                newName: "BirthPlace");

            migrationBuilder.AddColumn<string>(
                name: "MaidenName",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaidenName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Person",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "Person",
                newName: "profession");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Person",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Person",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Job",
                table: "Person",
                newName: "job");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Person",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "DeathPlace",
                table: "Person",
                newName: "deathPlace");

            migrationBuilder.RenameColumn(
                name: "DeathCause",
                table: "Person",
                newName: "deathCause");

            migrationBuilder.RenameColumn(
                name: "BirthPlace",
                table: "Person",
                newName: "birthPlace");
        }
    }
}
