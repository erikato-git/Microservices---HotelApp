using HotelApp.Services.HotelSearchAPI.DTOs;
using HotelApp.Services.HotelSearchAPI.Interfaces;
using HotelApp.Services.HotelSearchAPI.Service.IService;
using System.Linq;

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
            DateOnly CheckInDate = new DateOnly();
            DateOnly CheckOutDate = new DateOnly();

            try
            {
                CheckInDate = new DateOnly(int.Parse(CheckInDateItems[0]), int.Parse(CheckInDateItems[1]), int.Parse(CheckInDateItems[2]));
                CheckOutDate = new DateOnly(int.Parse(CheckOutDateItems[0]), int.Parse(CheckOutDateItems[1]), int.Parse(CheckOutDateItems[2]));

                var bookings = await _bookingAPI.GetBookingsByCountry(searchInput.Country);
                var hotels = await _hotelAPI.GetHotelsByCountry(searchInput.Country);

                // Test: If I test with 'searchInput' data within 01.06.2024 to 01.07.2024 for 'Downtown Hostel, Istedgade 1'
                // I should only be able to see rooms of 'DoubleRoom' and 'Dormitories'

                List<string> RemoveRooms = new List<string>();

                // [10] Find a more performance effective way to find if two elements in two list match each other than O^2 time
                /*  
                 *  1. Find if hotel-id match with a hotel-id in booking, 2. Check if 'CheckInDate' and 'CheckOutDate' for the booking item
                 *  are in between 'CheckInDate' and 'CheckOutDate' from user input, 3. true: then the RoomIds from the booking-item will be
                 *  loaded to a list of RoomIds that have to be removed in the response of hotels to the user
                 */
                foreach (var hotel in hotels)
                {
                    foreach (var booking in bookings)
                    {
                        if (hotel.Id.ToString().Equals(booking.HotelId))
                        {
                            if (booking.CheckInDate <= CheckInDate && CheckInDate <= booking.CheckOutDate)
                            {
                                List<string> NewRoomIds = [.. booking.RoomIds];
                                RemoveRooms.AddRange(NewRoomIds);
                            }
                        }
                    }
                }

                var RemoveRoomsGuid = RemoveRooms.ConvertAll(Guid.Parse);

                var HotelsWithOnlyAvailableRooms = hotels.Select(hotel =>
                {
                    // filter out rooms that don't have an id that 'RemoveRooms' contains
                    hotel.Rooms = hotel.Rooms.Where(room => !RemoveRoomsGuid.Contains(room.Id)).ToList();
                    return hotel;
                }).ToList();

                _response.IsSucces = true;
                _response.Result = HotelsWithOnlyAvailableRooms;

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
