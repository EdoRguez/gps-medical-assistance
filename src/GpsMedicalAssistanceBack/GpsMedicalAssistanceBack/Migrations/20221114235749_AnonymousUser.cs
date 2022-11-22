using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class AnonymousUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertUsers_Users_Id_User",
                table: "AlertUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "Id_User",
                table: "AlertUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Id_UserAnonymous",
                table: "AlertUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Alerts",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "UserAnonymous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnonymous", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertUsers_Id_UserAnonymous",
                table: "AlertUsers",
                column: "Id_UserAnonymous",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUsers_UserAnonymous_Id_UserAnonymous",
                table: "AlertUsers",
                column: "Id_UserAnonymous",
                principalTable: "UserAnonymous",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUsers_Users_Id_User",
                table: "AlertUsers",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertUsers_UserAnonymous_Id_UserAnonymous",
                table: "AlertUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertUsers_Users_Id_User",
                table: "AlertUsers");

            migrationBuilder.DropTable(
                name: "UserAnonymous");

            migrationBuilder.DropIndex(
                name: "IX_AlertUsers_Id_UserAnonymous",
                table: "AlertUsers");

            migrationBuilder.DropColumn(
                name: "Id_UserAnonymous",
                table: "AlertUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "Id_User",
                table: "AlertUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUsers_Users_Id_User",
                table: "AlertUsers",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
