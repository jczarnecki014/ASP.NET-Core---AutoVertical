using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMessagesOrderFromMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageOrder",
                table: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageOrder",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
