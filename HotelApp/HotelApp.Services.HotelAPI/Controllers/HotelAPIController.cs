using AutoMapper;
using HotelApp.Services.HotelAPI.Data;
using HotelApp.Services.HotelAPI.DTOs;
using HotelApp.Services.HotelAPI.Interfaces;
using HotelApp.Services.HotelAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Services.HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private ResponseDTO _response;
        private IHotelRepository _hotelRepository;

        public HotelAPIController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository; 
            _response = new ResponseDTO();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var result = await _hotelRepository.GetHotelById(id);

            if(result.IsSucces)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        [Route("GetHotelsByCountry/{country}")]
        public async Task<IActionResult> GetHotelsByCountry(string country)
        {
            var result = await _hotelRepository.GetHotelsByCountry(country);

            if (result.IsSucces)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);
        }

    }
}
