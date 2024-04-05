using HotelApp.Services.HotelSearchAPI.DTOs;

namespace HotelApp.Services.HotelSearchAPI.Service.IService
{
    public interface IBookingAPI_SvcHttpClient
    {
        Task<IEnumerable<Booking>> GetHotelsByCountry(string country);
    }
}
