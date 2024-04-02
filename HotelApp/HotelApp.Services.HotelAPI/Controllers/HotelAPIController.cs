using AutoMapper;
using HotelApp.Services.HotelAPI.Data;
using HotelApp.Services.HotelAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Services.HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public HotelAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id:string}")]
        public object GetHotelById(string id)
        {
            // [2] Look at how Neil handles guids for GetById-requests

            try
            {
                // call to db
                //_response.Result = _mapper.Map < "DisplayDTO" > ("database-obj");

                // for lists:
                //_response.Result = _mapper.Map <IEnumerable<"DisplayDTO">> ("database-obj");

            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
