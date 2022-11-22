using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class GenderChangeUserAonymous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserAnonymous",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserAnonymous",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
