using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class AddedAlerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentLocationLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentLocationLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DestinationLocationLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DestinationLocationLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertUserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertUserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Alert = table.Column<int>(type: "int", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false),
                    Id_AlertUserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertUser_Alert_Id_Alert",
                        column: x => x.Id_Alert,
                        principalTable: "Alert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertUser_AlertUserType_Id_AlertUserType",
                        column: x => x.Id_AlertUserType,
                        principalTable: "AlertUserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertUser_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertUser_Id_Alert",
                table: "AlertUser",
                column: "Id_Alert");

            migrationBuilder.CreateIndex(
                name: "IX_AlertUser_Id_AlertUserType",
                table: "AlertUser",
                column: "Id_AlertUserType");

            migrationBuilder.CreateIndex(
                name: "IX_AlertUser_Id_User",
                table: "AlertUser",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertUser");

            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "AlertUserType");
        }
    }
}
