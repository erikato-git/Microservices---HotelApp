using System.ComponentModel.DataAnnotations;

namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class SearchCriteriaInput
    {
        [Required]
        public int NumberOfPersons { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        public required string Country { get; set; }
    }
}
