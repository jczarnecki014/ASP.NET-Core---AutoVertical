using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "AdvertStats",
                newName: "AdvertViewsCount");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberDisplays",
                table: "AdvertStats",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberDisplays",
                table: "AdvertStats");

            migrationBuilder.RenameColumn(
                name: "AdvertViewsCount",
                table: "AdvertStats",
                newName: "Count");
        }
    }
}
