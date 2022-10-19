﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221019031036_AddedAlerts")]
    partial class AddedAlerts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentLocationLatitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CurrentLocationLongitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DestinationLocationLatitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DestinationLocationLongitude")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Alert");
                });

            modelBuilder.Entity("Entities.Models.AlertUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_Alert")
                        .HasColumnType("int");

                    b.Property<int>("Id_AlertUserType")
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Alert");

                    b.HasIndex("Id_AlertUserType");

                    b.HasIndex("Id_User");

                    b.ToTable("AlertUser");
                });

            modelBuilder.Entity("Entities.Models.AlertUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AlertUserType");
                });

            modelBuilder.Entity("Entities.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_FamilyType")
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("Id_FamilyType");

                    b.HasIndex("Id_User");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Entities.Models.FamilyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("FamilyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Padre"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Madre"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Abuelo/a"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hermano/a"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tío/a"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Primo/a"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Esposo/a"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Novio/a"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Amigo/a"
                        });
                });

            modelBuilder.Entity("Entities.Models.FavoritePlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<decimal>("Latitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("decimal(12,9)");

                    b.Property<decimal>("Longitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("decimal(12,9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id");

                    b.HasIndex("Id_User");

                    b.ToTable("FavoritePlaces");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.AlertUser", b =>
                {
                    b.HasOne("Entities.Models.Alert", "Alert")
                        .WithMany("AlertUsers")
                        .HasForeignKey("Id_Alert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.AlertUserType", "AlertUserType")
                        .WithMany()
                        .HasForeignKey("Id_AlertUserType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("AlertUsers")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alert");

                    b.Navigation("AlertUserType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Family", b =>
                {
                    b.HasOne("Entities.Models.FamilyType", "FamilyType")
                        .WithMany("Families")
                        .HasForeignKey("Id_FamilyType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Families")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamilyType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.FavoritePlace", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("FavoritePlaces")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Alert", b =>
                {
                    b.Navigation("AlertUsers");
                });

            modelBuilder.Entity("Entities.Models.FamilyType", b =>
                {
                    b.Navigation("Families");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("AlertUsers");

                    b.Navigation("Families");

                    b.Navigation("FavoritePlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
