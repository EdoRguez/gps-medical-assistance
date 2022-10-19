using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpsMedicalAssistanceBack.Migrations
{
    public partial class AddedAlerts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertUser_Alert_Id_Alert",
                table: "AlertUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertUser_AlertUserType_Id_AlertUserType",
                table: "AlertUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertUser_Users_Id_User",
                table: "AlertUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertUserType",
                table: "AlertUserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertUser",
                table: "AlertUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alert",
                table: "Alert");

            migrationBuilder.RenameTable(
                name: "AlertUserType",
                newName: "AlertUserTypes");

            migrationBuilder.RenameTable(
                name: "AlertUser",
                newName: "AlertUsers");

            migrationBuilder.RenameTable(
                name: "Alert",
                newName: "Alerts");

            migrationBuilder.RenameIndex(
                name: "IX_AlertUser_Id_User",
                table: "AlertUsers",
                newName: "IX_AlertUsers_Id_User");

            migrationBuilder.RenameIndex(
                name: "IX_AlertUser_Id_AlertUserType",
                table: "AlertUsers",
                newName: "IX_AlertUsers_Id_AlertUserType");

            migrationBuilder.RenameIndex(
                name: "IX_AlertUser_Id_Alert",
                table: "AlertUsers",
                newName: "IX_AlertUsers_Id_Alert");

            migrationBuilder.AlterColumn<decimal>(
                name: "DestinationLocationLongitude",
                table: "Alerts",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DestinationLocationLatitude",
                table: "Alerts",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLocationLongitude",
                table: "Alerts",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLocationLatitude",
                table: "Alerts",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertUserTypes",
                table: "AlertUserTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertUsers",
                table: "AlertUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AlertUserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Creador" });

            migrationBuilder.InsertData(
                table: "AlertUserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Usuario en Riesgo" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUsers_Alerts_Id_Alert",
                table: "AlertUsers",
                column: "Id_Alert",
                principalTable: "Alerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUsers_AlertUserTypes_Id_AlertUserType",
                table: "AlertUsers",
                column: "Id_AlertUserType",
                principalTable: "AlertUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUsers_Users_Id_User",
                table: "AlertUsers",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertUsers_Alerts_Id_Alert",
                table: "AlertUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertUsers_AlertUserTypes_Id_AlertUserType",
                table: "AlertUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertUsers_Users_Id_User",
                table: "AlertUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertUserTypes",
                table: "AlertUserTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertUsers",
                table: "AlertUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts");

            migrationBuilder.DeleteData(
                table: "AlertUserTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AlertUserTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "AlertUserTypes",
                newName: "AlertUserType");

            migrationBuilder.RenameTable(
                name: "AlertUsers",
                newName: "AlertUser");

            migrationBuilder.RenameTable(
                name: "Alerts",
                newName: "Alert");

            migrationBuilder.RenameIndex(
                name: "IX_AlertUsers_Id_User",
                table: "AlertUser",
                newName: "IX_AlertUser_Id_User");

            migrationBuilder.RenameIndex(
                name: "IX_AlertUsers_Id_AlertUserType",
                table: "AlertUser",
                newName: "IX_AlertUser_Id_AlertUserType");

            migrationBuilder.RenameIndex(
                name: "IX_AlertUsers_Id_Alert",
                table: "AlertUser",
                newName: "IX_AlertUser_Id_Alert");

            migrationBuilder.AlterColumn<decimal>(
                name: "DestinationLocationLongitude",
                table: "Alert",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)",
                oldPrecision: 12,
                oldScale: 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "DestinationLocationLatitude",
                table: "Alert",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)",
                oldPrecision: 12,
                oldScale: 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLocationLongitude",
                table: "Alert",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)",
                oldPrecision: 12,
                oldScale: 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLocationLatitude",
                table: "Alert",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,9)",
                oldPrecision: 12,
                oldScale: 9);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertUserType",
                table: "AlertUserType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertUser",
                table: "AlertUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alert",
                table: "Alert",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUser_Alert_Id_Alert",
                table: "AlertUser",
                column: "Id_Alert",
                principalTable: "Alert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUser_AlertUserType_Id_AlertUserType",
                table: "AlertUser",
                column: "Id_AlertUserType",
                principalTable: "AlertUserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertUser_Users_Id_User",
                table: "AlertUser",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
