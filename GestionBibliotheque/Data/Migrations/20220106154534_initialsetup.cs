using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionBibliotheque.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprunteur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunteur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oeuvre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: true),
                    AuteurID = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: false),
                    Langue = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oeuvre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oeuvre_Auteur_AuteurID",
                        column: x => x.AuteurID,
                        principalTable: "Auteur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oeuvre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePublication = table.Column<DateTime>(nullable: false),
                    NbPages = table.Column<int>(nullable: false),
                    NbCopies = table.Column<int>(nullable: false),
                    OeuvreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edition_Oeuvre_OeuvreId",
                        column: x => x.OeuvreId,
                        principalTable: "Oeuvre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edition_OeuvreId",
                table: "Edition",
                column: "OeuvreId");

            migrationBuilder.CreateIndex(
                name: "IX_Oeuvre_AuteurID",
                table: "Oeuvre",
                column: "AuteurID");

            migrationBuilder.CreateIndex(
                name: "IX_Oeuvre_GenreID",
                table: "Oeuvre",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edition");

            migrationBuilder.DropTable(
                name: "Emprunteur");

            migrationBuilder.DropTable(
                name: "Oeuvre");

            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
