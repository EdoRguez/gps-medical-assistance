using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class authenticationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "FavoritePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_User = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,9)", precision: 12, scale: 9, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,9)", precision: 12, scale: 9, nullable: false)
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

            migrationBuilder.UpdateData(
                table: "FamilyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Padre");

            migrationBuilder.UpdateData(
                table: "FamilyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Madre");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaces_Id_User",
                table: "FavoritePlaces",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritePlaces");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "FamilyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Papá");

            migrationBuilder.UpdateData(
                table: "FamilyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mamá");
        }
    }
}
