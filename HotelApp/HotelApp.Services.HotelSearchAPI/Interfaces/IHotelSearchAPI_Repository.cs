﻿using HotelApp.Services.HotelSearchAPI.DTOs;

namespace HotelApp.Services.HotelSearchAPI.Interfaces
{
    public interface IHotelSearchAPI_Repository
    {
        Task<ResponseDTO> HotelsSearchResult(SearchInput searchInput, PaginationSettings paginationSettings);

    }
}
