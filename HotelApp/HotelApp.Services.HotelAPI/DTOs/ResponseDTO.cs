namespace HotelApp.Services.HotelAPI.DTOs
{
    // ResponseDTO to carry the result and the error message from the repository improves the performance when using it with try-catch-blocks
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsSucces { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
