namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class Booking
    {
        public Guid Id { get; set; }
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
        public required DateTime CheckInDate { get; set; }
        public required DateTime CheckOutDate { get; set; }
        public List<string>? RoomIds { get; set; }
    }
}
