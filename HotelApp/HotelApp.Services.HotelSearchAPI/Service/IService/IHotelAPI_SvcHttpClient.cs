using HotelApp.Services.HotelSearchAPI.DTOs;

namespace HotelApp.Services.HotelSearchAPI.Service.IService
{
    public interface IHotelAPI_SvcHttpClient
    {
        Task<IEnumerable<Hotel>> GetHotelsByCountry(string country);
    }
}
