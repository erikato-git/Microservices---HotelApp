namespace HotelApp.Services.HotelAPI.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public required string HotelName { get; set; }
        public required string HotelAddress { get; set; }
        public string? HotelPicture { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public int Stars { get; set; }
        public string? ShortDescription { get; set; }
        public string? FullyDescription { get; set; }
        public List<string> PictureGallery { get; set; } = new List<string>();
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
