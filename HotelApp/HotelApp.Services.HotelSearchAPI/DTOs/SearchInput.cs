using System.ComponentModel.DataAnnotations;

namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class SearchInput
    {
        public required int NumberOfPersons { get; set; } = 2;
        public required string CheckInDate { get; set; } = "2024-6-1";
        public required string CheckOutDate { get; set; } = "2024-6-30";
        public required string Country { get; set; } = "denmark";
    }
}
