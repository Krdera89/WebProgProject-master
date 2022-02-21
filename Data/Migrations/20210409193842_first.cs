using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    DODeath = table.Column<DateTime>(nullable: false),
                    birthPlace = table.Column<string>(nullable: true),
                    deathPlace = table.Column<string>(nullable: true),
                    profession = table.Column<string>(nullable: true),
                    deathCause = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    contactPhone = table.Column<string>(nullable: true),
                    contactAddress = table.Column<string>(nullable: true),
                    contactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
