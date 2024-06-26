﻿using AutoMapper;
using HotelApp.Services.HotelAPI.Data;
using HotelApp.Services.HotelAPI.DTOs;
using HotelApp.Services.HotelAPI.Interfaces;
using HotelApp.Services.HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

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
                var filteredHotels = _db.Hotels.Include(x => x.Rooms).ThenInclude(x => x.Bed).Where(x => x.Country == country);

                if (!filteredHotels.Any())
                {
                    _response.Message = "No hotels contain this country";
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
