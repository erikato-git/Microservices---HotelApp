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
                DateTime CheckInDate = new DateTime(int.Parse(CheckInDateItems[0]), int.Parse(CheckInDateItems[1]), int.Parse(CheckInDateItems[2]));
                DateTime CheckOutDate = new DateTime(int.Parse(CheckOutDateItems[0]), int.Parse(CheckOutDateItems[1]), int.Parse(CheckOutDateItems[2]));
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }


            var bookings = await _bookingAPI.GetBookingsByCountry("denmark");
            var hotels = await _hotelAPI.GetHotelsByCountry("denmark");

            // TODO: Create the pseudo-code algorithm and check if the last part works

            // If I test with 'searchInput' data within 01.06.2024 to 01.07.2024 for 'Downtown Hostel, Istedgade 1'
            // I should only be able to see rooms of 'DoubleRoom' and 'Dormitories'

            // For each hotel check if HotelId in booking match the hotel's HotelId,
               // true: check if booking's checkInDate and checkOutDate are within the checkInDate and checkOutDate from user's input
                  // (true: remove RoomId in the hotel's rooms that match with the booking's RoomId) 
                  // true: load the RoomId for the booking to a 'RemoveRooms'-list


            List<Guid> RemoveRooms = new List<Guid>();

            var HotelsWithOnlyAvailableRooms = hotels.Select(hotel =>
            {
                // filter out rooms that don't have an id that 'RemoveRooms' contains
                hotel.Rooms = hotel.Rooms.Where(room => !RemoveRooms.Contains(room.Id)).ToList();
                return hotel;
            }).ToList();


            return _response;
        }
    }
}
