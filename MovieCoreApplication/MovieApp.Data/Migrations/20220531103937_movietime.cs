using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class movietime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieShowTimes",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieShowTimes", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_movieShowTimes_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieShowTimes_theatreModel_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModel",
                        principalColumn: "ThreatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimes_MovieId",
                table: "movieShowTimes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimes_TheatreId",
                table: "movieShowTimes",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieShowTimes");
        }
    }
}
