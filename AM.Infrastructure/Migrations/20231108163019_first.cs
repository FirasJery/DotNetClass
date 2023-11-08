using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistes",
                columns: table => new
                {
                    ArtisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationalite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistes", x => x.ArtisteId);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "Chansons",
                columns: table => new
                {
                    ChansonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    StyleMusicale = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    VuesYoutube = table.Column<int>(type: "int", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chansons", x => x.ChansonId);
                    table.ForeignKey(
                        name: "FK_Chansons_Artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    DateConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtisteFK = table.Column<int>(type: "int", nullable: false),
                    FestivalFK = table.Column<int>(type: "int", nullable: false),
                    Cachet = table.Column<double>(type: "float", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => new { x.ArtisteFK, x.FestivalFK, x.DateConcert });
                    table.ForeignKey(
                        name: "FK_Concerts_Artistes_ArtisteFK",
                        column: x => x.ArtisteFK,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Concerts_Festivals_FestivalFK",
                        column: x => x.FestivalFK,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtisteFestival_FestivalsFestivalId",
                table: "ArtisteFestival",
                column: "FestivalsFestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Chansons_ArtisteFk",
                table: "Chansons",
                column: "ArtisteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_FestivalFK",
                table: "Concerts",
                column: "FestivalFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtisteFestival");

            migrationBuilder.DropTable(
                name: "Chansons");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Artistes");

            migrationBuilder.DropTable(
                name: "Festivals");
        }
    }
}
