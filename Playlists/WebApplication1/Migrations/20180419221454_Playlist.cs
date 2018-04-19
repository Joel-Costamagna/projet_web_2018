using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Playlist.Migrations
{
    public partial class Playlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    isPublic = table.Column<bool>(nullable: false),
                    nom = table.Column<string>(nullable: true),
                    proprietaireId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_proprietaireId",
                        column: x => x.proprietaireId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musique",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlaylistId = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    duree = table.Column<double>(nullable: false),
                    nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musique_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musique_PlaylistId",
                table: "Musique",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_proprietaireId",
                table: "Playlists",
                column: "proprietaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musique");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
