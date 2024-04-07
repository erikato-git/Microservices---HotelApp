using System.ComponentModel.DataAnnotations;

namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class SearchInput
    {
        public required int NumberOfPersons { get; set; }
        // NB: Format ex. "2024-07-10"
        public required string CheckInDate { get; set; }
        public required string CheckOutDate { get; set; }
        public required string Country { get; set; }
    }
}
