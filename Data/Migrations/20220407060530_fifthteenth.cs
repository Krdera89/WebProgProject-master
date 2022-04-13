using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class fifthteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
