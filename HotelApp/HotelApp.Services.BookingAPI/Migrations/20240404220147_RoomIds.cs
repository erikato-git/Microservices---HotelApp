using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp.Services.BookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoomIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomIds",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomIds",
                table: "Bookings");
        }
    }
}
