using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtisteFestival");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtisteFestival",
                columns: table => new
                {
                    ArtistesArtisteId = table.Column<int>(type: "int", nullable: false),
                    FestivalsFestivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtisteFestival", x => new { x.ArtistesArtisteId, x.FestivalsFestivalId });
                    table.ForeignKey(
                        name: "FK_ArtisteFestival_Artistes_ArtistesArtisteId",
                        column: x => x.ArtistesArtisteId,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtisteFestival_Festivals_FestivalsFestivalId",
                        column: x => x.FestivalsFestivalId,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtisteFestival_FestivalsFestivalId",
                table: "ArtisteFestival",
                column: "FestivalsFestivalId");
        }
    }
}
