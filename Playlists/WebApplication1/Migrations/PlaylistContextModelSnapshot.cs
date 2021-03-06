﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Playlist.Models;
using System;

namespace Playlist.Migrations
{
    [DbContext(typeof(PlaylistContext))]
    partial class PlaylistContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Playlist.Models.Musique", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<double>("Duree");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("PlaylistModelId");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PlaylistModelId");

                    b.ToTable("Musique");
                });

            modelBuilder.Entity("Playlist.Models.PlaylistModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ProprietaireName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Playlist.Models.Tags", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlaylistModelId");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistModelId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Playlist.Models.Musique", b =>
                {
                    b.HasOne("Playlist.Models.PlaylistModel")
                        .WithMany("Musiques")
                        .HasForeignKey("PlaylistModelId");
                });

            modelBuilder.Entity("Playlist.Models.Tags", b =>
                {
                    b.HasOne("Playlist.Models.PlaylistModel")
                        .WithMany("Tags")
                        .HasForeignKey("PlaylistModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
