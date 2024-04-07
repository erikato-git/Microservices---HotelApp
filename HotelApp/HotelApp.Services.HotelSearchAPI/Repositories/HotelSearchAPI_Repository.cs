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

        public async Task<ResponseDTO> HotelsSearchResult(SearchInput searchInput)
        {
            /*
             * The Synchronous communication violates the princple in microservices that each services should be autonomous.
             * [8] Consider to use an asynchronous communication solution 
             */

            string[] CheckInDateItems = searchInput.CheckInDate.Split('-');
            string[] CheckOutDateItems = searchInput.CheckOutDate.Split('-');

            try
            {
                DateOnly CheckInDate = new DateOnly(int.Parse(CheckInDateItems[2]), int.Parse(CheckInDateItems[1]), int.Parse(CheckInDateItems[0]));
                DateOnly CheckOutDate = new DateOnly(int.Parse(CheckOutDateItems[2]), int.Parse(CheckOutDateItems[1]), int.Parse(CheckOutDateItems[0]));
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }


            var bookings = await _bookingAPI.GetBookingsByCountry("denmark");
            var hotels = await _hotelAPI.GetHotelsByCountry("denmark");

            // If I test with 'searchInput' data within 01.06.2024 to 01.07.2024 for 'Downtown Hostel, Istedgade 1'
            // I should only be able to see rooms of 'DoubleRoom' and 'Dormitories'

            // if hotels match 

            _response.Result = bookings;

            return _response;
        }
    }
}
