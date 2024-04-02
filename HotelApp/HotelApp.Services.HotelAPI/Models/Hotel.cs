namespace HotelApp.Services.HotelAPI.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
