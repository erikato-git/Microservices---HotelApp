using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp.Services.BookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class HotelCountry_HotelCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelCity",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotelCountry",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelCity",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelCountry",
                table: "Bookings");
        }
    }
}
