﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicOrg.Models;

namespace MusicOrg.Migrations
{
    [DbContext(typeof(MusicOrgContext))]
    partial class MusicOrgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MusicOrg.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicOrg.Models.ArtistVinyl", b =>
                {
                    b.Property<int>("ArtistVinylId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<int>("VinylId");

                    b.HasKey("ArtistVinylId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("VinylId");

                    b.ToTable("ArtistVinyl");
                });

            modelBuilder.Entity("MusicOrg.Models.Vinyl", b =>
                {
                    b.Property<int>("VinylId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("VinylId");

                    b.ToTable("Vinyls");
                });

            modelBuilder.Entity("MusicOrg.Models.ArtistVinyl", b =>
                {
                    b.HasOne("MusicOrg.Models.Artist", "Artist")
                        .WithMany("Vinyls")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicOrg.Models.Vinyl", "Vinyl")
                        .WithMany("Artists")
                        .HasForeignKey("VinylId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}