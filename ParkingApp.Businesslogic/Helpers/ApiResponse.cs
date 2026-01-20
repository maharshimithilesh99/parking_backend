namespace ParkingApp.API.Helpers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(T? data, bool success = true, string message = "")
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }
}
