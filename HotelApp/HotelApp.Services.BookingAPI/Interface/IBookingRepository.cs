using HotelApp.Services.BookingAPI.DTOs;

namespace HotelApp.Services.BookingAPI.Interface
{
    public interface IBookingRepository
    {
        Task<ResponseDTO> GetHotelsByCountry(string country);

    }
}
