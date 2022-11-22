using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class AddedUserAnonymousProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserAnonymous",
                type: "character varying(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserAnonymous",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<short>(
                name: "Age",
                table: "UserAnonymous",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<char>(
                name: "Gender",
                table: "UserAnonymous",
                type: "character(1)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "UserAnonymous",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "UserAnonymous",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserAnonymous");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserAnonymous");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "UserAnonymous");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "UserAnonymous");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserAnonymous",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserAnonymous",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
