using HotelApp.Services.HotelSearchAPI.DTOs;
using HotelApp.Services.HotelSearchAPI.Service.IService;
using Newtonsoft.Json;

namespace HotelApp.Services.HotelSearchAPI.Service
{
    public class BookingAPI_SvcHttpClient : IBookingAPI_SvcHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public BookingAPI_SvcHttpClient(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCountry(string country)
        {
            var client = _httpClientFactory.CreateClient("BookingAPI");
            var httpResponse = await client.GetAsync("api/Bookings/GetHotelsByCountry/" + country);
            var apiContent = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IEnumerable<Booking>>(Convert.ToString(apiContent));
            if(response == null)
            {
                return new List<Booking>(); // empty list
            }

            return response;

        }
    }
}
