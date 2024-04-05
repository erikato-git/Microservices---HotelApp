namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class Room
    {
        public Guid Id { get; set; }
        public required string RoomType { get; set; }
        public required Bed Bed { get; set; }
        public int AmountOfBeds { get; set; }
        public string? RoomPicture { get; set; }
        public List<string> Extras { get; set; } = new List<string>();

    }
}
