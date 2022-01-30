﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoonMissing.Data.Deploy;

#nullable disable

namespace MoonMissing.Data.Deploy.Migrations
{
    [DbContext(typeof(MoonMissingDeployDbContext))]
    [Migration("20220130050613_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("MoonMissing.Data.Entities.ImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.KingdomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kingdom");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.MoonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMultiMoon")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRockMoon")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSubAreaMoon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KingdomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MoonName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Quadrant")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KingdomId");

                    b.ToTable("Moon");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.MoonImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("MoonId");

                    b.ToTable("MoonImage");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.MoonEntity", b =>
                {
                    b.HasOne("MoonMissing.Data.Entities.KingdomEntity", "Kingdom")
                        .WithMany("Moons")
                        .HasForeignKey("KingdomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.MoonImageEntity", b =>
                {
                    b.HasOne("MoonMissing.Data.Entities.ImageEntity", "Image")
                        .WithMany("MoonImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoonMissing.Data.Entities.MoonEntity", "Moon")
                        .WithMany("MoonImages")
                        .HasForeignKey("MoonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Moon");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.ImageEntity", b =>
                {
                    b.Navigation("MoonImages");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.KingdomEntity", b =>
                {
                    b.Navigation("Moons");
                });

            modelBuilder.Entity("MoonMissing.Data.Entities.MoonEntity", b =>
                {
                    b.Navigation("MoonImages");
                });
#pragma warning restore 612, 618
        }
    }
}
