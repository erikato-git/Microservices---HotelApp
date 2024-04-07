using System.ComponentModel.DataAnnotations;

namespace HotelApp.Services.BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        // OBS: avoid 'Guid' as datatype for 'HotelId', EF will interpret it as an 'unique-identifier'
        public required string HotelId { get; set; }
        public required string HotelName { get; set; }
        public required string HotelAddress { get; set; }
        public required string HotelCountry { get; set; }
        public required string HotelCity { get; set; }
        public int Stars { get; set; }
        public required string CustomerEmail { get; set; }
        public int People { get; set; }
        public string? CustomerAddress { get; set; }
        public required string CustomerFullName { get; set; }
        public required string OrderRoomsTextString { get; set; }
        public required DateOnly CheckInDate { get; set; }
        public required DateOnly CheckOutDate { get; set; }
        public List<string>? RoomIds { get; set;}

    }
}
