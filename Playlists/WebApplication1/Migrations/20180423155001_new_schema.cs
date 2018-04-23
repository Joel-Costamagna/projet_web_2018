using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Playlist.Migrations
{
    public partial class new_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Playlists",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "isPublic",
                table: "Playlists",
                newName: "IsPublic");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Playlists",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "proprietaire_name",
                table: "Playlists",
                newName: "ProprietaireName");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Musique",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "duree",
                table: "Musique",
                newName: "Duree");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Musique",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Musique",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Playlists",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Playlists",
                newName: "isPublic");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Playlists",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ProprietaireName",
                table: "Playlists",
                newName: "proprietaire_name");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Musique",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Musique",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "Duree",
                table: "Musique",
                newName: "duree");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Musique",
                newName: "description");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }
    }
}
