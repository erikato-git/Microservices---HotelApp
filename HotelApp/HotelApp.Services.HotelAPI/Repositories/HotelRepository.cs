using AutoMapper;
using HotelApp.Services.HotelAPI.Data;
using HotelApp.Services.HotelAPI.DTOs;
using HotelApp.Services.HotelAPI.Interfaces;
using HotelApp.Services.HotelAPI.Models;

namespace HotelApp.Services.HotelAPI.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;

        public HotelRepository(AppDbContext db, IMapper mapper) 
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetHotelById(Guid id) 
        {
            if(id == Guid.Empty)
            {
                _response.Message = "Id is empty";
                return _response;
            }

            try
            {
                Hotel? found = await _db.Hotels.FindAsync(id);

                if(found == null) 
                {
                    _response.Message = "Hotel is not found in Db";
                    return _response;
                }

                _response.IsSucces = true;
                _response.Result = found;
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
