using HotelApp.Services.HotelAPI.DTOs;

namespace HotelApp.Services.HotelAPI.Interfaces
{
    public interface IHotelRepository
    {
        Task<ResponseDTO> GetHotelById(Guid id);
        Task<ResponseDTO> GetHotelsByCountry(string country);
    }
}
