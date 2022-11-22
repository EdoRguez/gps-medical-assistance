﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221120194713_ChangedTypeUserAnonymous")]
    partial class ChangedTypeUserAnonymous
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("CurrentLocationLatitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("numeric(12,9)");

                    b.Property<decimal>("CurrentLocationLongitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("numeric(12,9)");

                    b.Property<decimal>("DestinationLocationLatitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("numeric(12,9)");

                    b.Property<decimal>("DestinationLocationLongitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("numeric(12,9)");

                    b.HasKey("Id");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Entities.Models.AlertUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Alert")
                        .HasColumnType("integer");

                    b.Property<int>("Id_AlertUserType")
                        .HasColumnType("integer");

                    b.Property<int?>("Id_User")
                        .HasColumnType("integer");

                    b.Property<int?>("Id_UserAnonymous")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id_Alert");

                    b.HasIndex("Id_AlertUserType");

                    b.HasIndex("Id_User");

                    b.HasIndex("Id_UserAnonymous")
                        .IsUnique();

                    b.ToTable("AlertUsers");
                });

            modelBuilder.Entity("Entities.Models.AlertUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("AlertUserTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Creador"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Usuario en Riesgo"
                        });
                });

            modelBuilder.Entity("Entities.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_FamilyType")
                        .HasColumnType("integer");

                    b.Property<int>("Id_User")
                        .HasColumnType("integer");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("Id");

                    b.HasIndex("Id_FamilyType");

                    b.HasIndex("Id_User");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Entities.Models.FamilyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

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
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_User")
                        .HasColumnType("integer");

                    b.Property<decimal>("Latitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("numeric(12,9)");

                    b.Property<decimal>("Longitude")
                        .HasPrecision(12, 9)
                        .HasColumnType("numeric(12,9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("character varying(350)");

                    b.HasKey("Id");

                    b.HasIndex("Id_User");

                    b.ToTable("FavoritePlaces");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.UserAnonymous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short?>("Age")
                        .HasColumnType("smallint");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<float?>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Identification")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("Id");

                    b.ToTable("UserAnonymous");
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
                        .HasForeignKey("Id_User");

                    b.HasOne("Entities.Models.UserAnonymous", "UserAnonymous")
                        .WithOne("AlertUser")
                        .HasForeignKey("Entities.Models.AlertUser", "Id_UserAnonymous");

                    b.Navigation("Alert");

                    b.Navigation("AlertUserType");

                    b.Navigation("User");

                    b.Navigation("UserAnonymous");
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

            modelBuilder.Entity("Entities.Models.UserAnonymous", b =>
                {
                    b.Navigation("AlertUser");
                });
#pragma warning restore 612, 618
        }
    }
}