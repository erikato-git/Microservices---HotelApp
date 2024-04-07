using HotelApp.Services.HotelSearchAPI.DTOs;
using HotelApp.Services.HotelSearchAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Services.HotelSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelSearchAPIController : ControllerBase
    {
        private ResponseDTO _response;
        private IHotelSearchAPI_Repository _hotelSearchAPI_Repository;

        public HotelSearchAPIController(IHotelSearchAPI_Repository hotelSearchAPI_Repository)
        {
            _hotelSearchAPI_Repository = hotelSearchAPI_Repository;
            _response = new ResponseDTO();
        }

        [HttpGet]
        [Route("HotelsSearchResult")]
        public async Task<IActionResult> HotelsSearchResult([FromQuery]SearchInput searchInput)
        {
            var result = await _hotelSearchAPI_Repository.HotelsSearchResult(searchInput);

            if (result.IsSucces)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);
        }

    }
}
