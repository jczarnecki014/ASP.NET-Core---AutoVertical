using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class AddImgGalleryAndDeleteGalleryIdFromVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_ImgGallery_GalleryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_GalleryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "imgEightUrl",
                table: "ImgGallery");

            migrationBuilder.DropColumn(
                name: "imgFiveUrl",
                table: "ImgGallery");

            migrationBuilder.DropColumn(
                name: "imgFourUrl",
                table: "ImgGallery");

            migrationBuilder.DropColumn(
                name: "imgSevenUrl",
                table: "ImgGallery");

            migrationBuilder.DropColumn(
                name: "imgSixUrl",
                table: "ImgGallery");

            migrationBuilder.DropColumn(
                name: "imgThreeUrl",
                table: "ImgGallery");

            migrationBuilder.DropColumn(
                name: "imgTwoUrl",
                table: "ImgGallery");

            migrationBuilder.RenameColumn(
                name: "imgOneUrl",
                table: "ImgGallery",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "ImgGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "ImgGallery");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ImgGallery",
                newName: "imgOneUrl");

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "imgEightUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgFiveUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgFourUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgSevenUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgSixUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgThreeUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgTwoUrl",
                table: "ImgGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_GalleryId",
                table: "Vehicles",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_ImgGallery_GalleryId",
                table: "Vehicles",
                column: "GalleryId",
                principalTable: "ImgGallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
