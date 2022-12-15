using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesInVehiclesPropertiesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectrisGlasses",
                table: "Trucks",
                newName: "ElectrisWindows");

            migrationBuilder.AlterColumn<string>(
                name: "Imported",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "ASR",
                table: "Trucks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASR",
                table: "Trucks");

            migrationBuilder.RenameColumn(
                name: "ElectrisWindows",
                table: "Trucks",
                newName: "ElectrisGlasses");

            migrationBuilder.AlterColumn<bool>(
                name: "Imported",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
