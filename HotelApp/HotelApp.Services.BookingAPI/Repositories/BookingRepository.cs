using AutoMapper;
using Azure;
using HotelApp.Services.BookingAPI.Data;
using HotelApp.Services.BookingAPI.DTOs;
using HotelApp.Services.BookingAPI.Interface;

namespace HotelApp.Services.BookingAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public BookingRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        // [6] Should I ignore this warning or address it
        public async Task<ResponseDTO> GetHotelsByCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                _response.Message = "Country is empty";
                return _response;
            }

            try
            {
                var filteredHotels = _db.Bookings.Where(x => x.HotelCountry == country);

                if(!filteredHotels.Any())
                {
                    _response.Message = "No bookings contain this country as 'HotelCountry'";
                    return _response;
                }

                _response.IsSucces = true;
                _response.Result = filteredHotels;
            }
            catch (Exception ex)
            {
                // [4] Consider to put in logger here
                _response.Message = ex.Message;
            }

            return _response;
        }

    }
}
