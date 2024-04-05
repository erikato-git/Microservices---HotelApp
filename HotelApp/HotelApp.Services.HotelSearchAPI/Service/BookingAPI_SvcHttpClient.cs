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

        public async Task<IEnumerable<Booking>> GetHotelsByCountry(string country)
        {
            var client = _httpClientFactory.CreateClient("BookingAPI");
            var httpResponse = await client.GetAsync("$/api/BookingAPI/GetHotelsByCountry/" + country);
            var apiContent = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);

            if (response == null || !response.IsSucces)
            {
                return new List<Booking>();   // empty list
            }

            return JsonConvert.DeserializeObject<IEnumerable<Booking>>(Convert.ToString(response.Result));
        }
    }
}
