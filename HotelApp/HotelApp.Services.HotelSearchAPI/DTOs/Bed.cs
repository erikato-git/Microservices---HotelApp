namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class Bed
    {
        public Guid Id { get; set; }
        public required string BedType { get; set; }
        public double PricePrNight { get; set; }
        public int PeopleCapacity { get; set; }
        public string? BedPicture { get; set; }

    }
}
