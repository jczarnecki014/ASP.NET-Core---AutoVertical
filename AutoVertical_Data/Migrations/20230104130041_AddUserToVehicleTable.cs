using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vehicles");
        }
    }
}
