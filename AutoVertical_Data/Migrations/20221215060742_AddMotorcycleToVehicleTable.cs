using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class AddMotorcycleToVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotorcycleId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MotorcycleId",
                table: "Vehicles",
                column: "MotorcycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Motorcycles_MotorcycleId",
                table: "Vehicles",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Motorcycles_MotorcycleId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_MotorcycleId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "Vehicles");
        }
    }
}
