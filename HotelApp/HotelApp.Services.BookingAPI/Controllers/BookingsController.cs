using HotelApp.Services.BookingAPI.DTOs;
using HotelApp.Services.BookingAPI.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Services.BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private ResponseDTO _response;
        private IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            _response = new ResponseDTO();
        }

        [HttpGet]
        [Route("GetHotelsByCountry/{country}")]
        public async Task<IActionResult> GetHotelsByCountry(string country)
        {
            var result = await _bookingRepository.GetHotelsByCountry(country);

            if (result.IsSucces)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);
        }
    }
}
