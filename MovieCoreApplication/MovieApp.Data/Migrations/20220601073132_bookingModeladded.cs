using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class bookingModeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingModels",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    MovieSTimeShowId = table.Column<int>(type: "int", nullable: true),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingModels", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookingModels_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModels_movieShowTimes_MovieSTimeShowId",
                        column: x => x.MovieSTimeShowId,
                        principalTable: "movieShowTimes",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookingModels_theatreModel_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModel",
                        principalColumn: "ThreatreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModels_userModel_UserId",
                        column: x => x.UserId,
                        principalTable: "userModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_MovieId",
                table: "bookingModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_MovieSTimeShowId",
                table: "bookingModels",
                column: "MovieSTimeShowId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_TheatreId",
                table: "bookingModels",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_UserId",
                table: "bookingModels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingModels");
        }
    }
}
