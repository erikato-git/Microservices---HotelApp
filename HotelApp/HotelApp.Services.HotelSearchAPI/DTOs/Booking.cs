namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class Booking
    {
        public Guid Id { get; set; }
        public required string HotelId { get; set; }
        // [9] Figure out at last if 'HotelName' and 'HotelAddress' are necessary properties, or if it would be smarter to extract them with 'HotelId'
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
        public List<string>? RoomIds { get; set; }
    }
}
