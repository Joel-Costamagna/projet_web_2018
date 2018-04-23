using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Playlist.Migrations
{
    public partial class Playlist_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    isPublic = table.Column<bool>(nullable: false),
                    nom = table.Column<string>(maxLength: 60, nullable: false),
                    proprietaire_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musique",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlaylistModelId = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    duree = table.Column<double>(nullable: false),
                    nom = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musique_Playlists_PlaylistModelId",
                        column: x => x.PlaylistModelId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlaylistModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Playlists_PlaylistModelId",
                        column: x => x.PlaylistModelId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musique_PlaylistModelId",
                table: "Musique",
                column: "PlaylistModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PlaylistModelId",
                table: "Tags",
                column: "PlaylistModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musique");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
