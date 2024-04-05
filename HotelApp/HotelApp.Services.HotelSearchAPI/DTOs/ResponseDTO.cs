namespace HotelApp.Services.HotelSearchAPI.DTOs
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsSucces { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
