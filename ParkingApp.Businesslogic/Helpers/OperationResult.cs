namespace ParkingApp.Businesslogic.Helpers
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static OperationResult<T> Fail(string message) =>
            new OperationResult<T> { Success = false, Message = message };

        public static OperationResult<T> Ok(T? data, string message = "") =>
            new OperationResult<T> { Success = true, Message = message, Data = data };
    }
}
