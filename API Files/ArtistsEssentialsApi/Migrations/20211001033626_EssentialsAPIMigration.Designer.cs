﻿// <auto-generated />
using System;
using ArtistsEssentialsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArtistsEssentialsApi.Migrations
{
    [DbContext(typeof(EssentialsContext))]
    [Migration("20211001033626_EssentialsAPIMigration")]
    partial class EssentialsAPIMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtistsEssentialsApi.Models.EssentialAlbum", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BillboardPeakUS")
                        .HasColumnType("int");

                    b.Property<string>("Certification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EssentialArtistId")
                        .HasColumnType("bigint");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GrammyNominations")
                        .HasColumnType("int");

                    b.Property<int?>("GrammyWins")
                        .HasColumnType("int");

                    b.Property<decimal?>("MetacriticRating")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("PitchforkRating")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal?>("RateYourMusicRating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<decimal?>("RollingStoneRating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeeksOnChartUS")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EssentialArtistId");

                    b.ToTable("EssentialAlbums");
                });

            modelBuilder.Entity("ArtistsEssentialsApi.Models.EssentialArtist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EssentialArtists");
                });

            modelBuilder.Entity("ArtistsEssentialsApi.Models.EssentialAlbum", b =>
                {
                    b.HasOne("ArtistsEssentialsApi.Models.EssentialArtist", null)
                        .WithMany("EssentialAlbums")
                        .HasForeignKey("EssentialArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtistsEssentialsApi.Models.EssentialArtist", b =>
                {
                    b.Navigation("EssentialAlbums");
                });
#pragma warning restore 612, 618
        }
    }
}
