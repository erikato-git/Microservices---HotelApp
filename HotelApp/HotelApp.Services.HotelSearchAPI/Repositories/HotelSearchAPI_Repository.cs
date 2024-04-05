using HotelApp.Services.HotelSearchAPI.DTOs;
using HotelApp.Services.HotelSearchAPI.Interfaces;
using HotelApp.Services.HotelSearchAPI.Service.IService;

namespace HotelApp.Services.HotelSearchAPI.Repositories
{
    public class HotelSearchAPI_Repository : IHotelSearchAPI_Repository
    {
        private IBookingAPI_SvcHttpClient _bookingAPI;
        private IHotelAPI_SvcHttpClient _hotelAPI;
        private ResponseDTO _response;

        public HotelSearchAPI_Repository(IBookingAPI_SvcHttpClient bookingAPI, IHotelAPI_SvcHttpClient hotelAPI)
        {
            _bookingAPI = bookingAPI;
            _hotelAPI = hotelAPI;
            _response = new ResponseDTO();
        }

        public async Task<ResponseDTO> TestSynchronization()
        {
            var bookings = await _bookingAPI.GetBookingsByCountry("denmark");
            var hotels = await _hotelAPI.GetHotelsByCountry("denmark");

            // TODO: Begin at implementing Search-functionality from Neil's example


            _response.Result = bookings;

            return _response;
        }
    }
}
