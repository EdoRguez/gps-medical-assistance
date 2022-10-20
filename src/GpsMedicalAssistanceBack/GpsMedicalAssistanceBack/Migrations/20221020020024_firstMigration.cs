using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrentLocationLatitude = table.Column<decimal>(type: "numeric(12,9)", precision: 12, scale: 9, nullable: false),
                    CurrentLocationLongitude = table.Column<decimal>(type: "numeric(12,9)", precision: 12, scale: 9, nullable: false),
                    DestinationLocationLatitude = table.Column<decimal>(type: "numeric(12,9)", precision: 12, scale: 9, nullable: false),
                    DestinationLocationLongitude = table.Column<decimal>(type: "numeric(12,9)", precision: 12, scale: 9, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertUserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertUserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Identification = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Alert = table.Column<int>(type: "integer", nullable: false),
                    Id_User = table.Column<int>(type: "integer", nullable: false),
                    Id_AlertUserType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertUsers_Alerts_Id_Alert",
                        column: x => x.Id_Alert,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertUsers_AlertUserTypes_Id_AlertUserType",
                        column: x => x.Id_AlertUserType,
                        principalTable: "AlertUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertUsers_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_User = table.Column<int>(type: "integer", nullable: false),
                    Id_FamilyType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Identification = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Families_FamilyTypes_Id_FamilyType",
                        column: x => x.Id_FamilyType,
                        principalTable: "FamilyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Families_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_User = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(12,9)", precision: 12, scale: 9, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(12,9)", precision: 12, scale: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePlaces_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlertUserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Creador" },
                    { 2, "Usuario en Riesgo" }
                });

            migrationBuilder.InsertData(
                table: "FamilyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Padre" },
                    { 2, "Madre" },
                    { 3, "Abuelo/a" },
                    { 4, "Hermano/a" },
                    { 5, "Tío/a" },
                    { 6, "Primo/a" },
                    { 7, "Esposo/a" },
                    { 8, "Novio/a" },
                    { 9, "Amigo/a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertUsers_Id_Alert",
                table: "AlertUsers",
                column: "Id_Alert");

            migrationBuilder.CreateIndex(
                name: "IX_AlertUsers_Id_AlertUserType",
                table: "AlertUsers",
                column: "Id_AlertUserType");

            migrationBuilder.CreateIndex(
                name: "IX_AlertUsers_Id_User",
                table: "AlertUsers",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Families_Id_FamilyType",
                table: "Families",
                column: "Id_FamilyType");

            migrationBuilder.CreateIndex(
                name: "IX_Families_Id_User",
                table: "Families",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaces_Id_User",
                table: "FavoritePlaces",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertUsers");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "FavoritePlaces");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "AlertUserTypes");

            migrationBuilder.DropTable(
                name: "FamilyTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
