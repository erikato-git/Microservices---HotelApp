using HotelApp.Services.HotelSearchAPI.DTOs;
using HotelApp.Services.HotelSearchAPI.Service.IService;
using Newtonsoft.Json;

namespace HotelApp.Services.HotelSearchAPI.Service
{
    public class HotelAPI_SvcHttpClient : IHotelAPI_SvcHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public HotelAPI_SvcHttpClient(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCountry(string country)
        {
            var client = _httpClientFactory.CreateClient("HotelAPI");
            var httpResponse = await client.GetAsync("$/api/HotelAPI/GetHotelsByCountry/" + country);
            var apiContent = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);

            if (response == null || !response.IsSucces)
            {
                return new List<Hotel>();   // empty list
            }

            return JsonConvert.DeserializeObject<IEnumerable<Hotel>>(Convert.ToString(response.Result));
        }
    }
}
