using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgProject.Data.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlotID",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "job",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middleName",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notes",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cemetary",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cemetary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notes = table.Column<string>(nullable: true),
                    picPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plot",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plotNumber = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    CemID = table.Column<int>(nullable: false),
                    Personid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plot_Person_Personid",
                        column: x => x.Personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PictureCemetary",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CemetaryID = table.Column<int>(nullable: false),
                    pictureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureCemetary", x => x.id);
                    table.ForeignKey(
                        name: "FK_PictureCemetary_Cemetary_CemetaryID",
                        column: x => x.CemetaryID,
                        principalTable: "Cemetary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureCemetary_Picture_pictureID",
                        column: x => x.pictureID,
                        principalTable: "Picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PicturePerson",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(nullable: false),
                    pictureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicturePerson", x => x.id);
                    table.ForeignKey(
                        name: "FK_PicturePerson_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PicturePerson_Picture_pictureID",
                        column: x => x.pictureID,
                        principalTable: "Picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPlot",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plotID = table.Column<int>(nullable: false),
                    personID = table.Column<int>(nullable: false)
               /* },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPlot", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonPlot_Person_personID",
                        column: x => x.personID,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonPlot_Plot_plotID",
                        column: x => x.plotID,
                        principalTable: "Plot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);*/
                });

            migrationBuilder.CreateTable(
                name: "PicturePlot",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plotID = table.Column<int>(nullable: false),
                    pictureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicturePlot", x => x.id);
                    table.ForeignKey(
                        name: "FK_PicturePlot_Picture_pictureID",
                        column: x => x.pictureID,
                        principalTable: "Picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PicturePlot_Plot_plotID",
                        column: x => x.plotID,
                        principalTable: "Plot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlotCemetary",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CemetaryID = table.Column<int>(nullable: false),
                    plotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotCemetary", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlotCemetary_Cemetary_CemetaryID",
                        column: x => x.CemetaryID,
                        principalTable: "Cemetary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlotCemetary_Plot_plotID",
                        column: x => x.plotID,
                        principalTable: "Plot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_PlotID",
                table: "Person",
                column: "PlotID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPlot_personID",
                table: "PersonPlot",
                column: "personID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPlot_plotID",
                table: "PersonPlot",
                column: "plotID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureCemetary_CemetaryID",
                table: "PictureCemetary",
                column: "CemetaryID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureCemetary_pictureID",
                table: "PictureCemetary",
                column: "pictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PicturePerson_PersonID",
                table: "PicturePerson",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PicturePerson_pictureID",
                table: "PicturePerson",
                column: "pictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PicturePlot_pictureID",
                table: "PicturePlot",
                column: "pictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PicturePlot_plotID",
                table: "PicturePlot",
                column: "plotID");

            migrationBuilder.CreateIndex(
                name: "IX_Plot_Personid",
                table: "Plot",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_PlotCemetary_CemetaryID",
                table: "PlotCemetary",
                column: "CemetaryID");

            migrationBuilder.CreateIndex(
                name: "IX_PlotCemetary_plotID",
                table: "PlotCemetary",
                column: "plotID");

           /* migrationBuilder.AddForeignKey(
                name: "FK_Person_Plot_PlotID",
                table: "Person",
                column: "PlotID",
                principalTable: "Plot",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Plot_PlotID",
                table: "Person");

            migrationBuilder.DropTable(
                name: "PersonPlot");

            migrationBuilder.DropTable(
                name: "PictureCemetary");

            migrationBuilder.DropTable(
                name: "PicturePerson");

            migrationBuilder.DropTable(
                name: "PicturePlot");

            migrationBuilder.DropTable(
                name: "PlotCemetary");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Cemetary");

            migrationBuilder.DropTable(
                name: "Plot");

            migrationBuilder.DropIndex(
                name: "IX_Person_PlotID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PlotID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "job",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "middleName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "notes",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Person");
        }
    }
}
