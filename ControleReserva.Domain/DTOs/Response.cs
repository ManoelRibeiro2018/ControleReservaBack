namespace ControleReserva.Domain.DTOs
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Result { get; set; }
        public bool Success { get; set; }

        public static Response Failure(string message, bool success, int statusCode) => new()
        {
            Message = message,
            Success = success,
            StatusCode = statusCode
        };

        public static Response Successful(string message, bool success, int statusCode) => new()
        {
            Message = message,
            Success = success,
            StatusCode = statusCode
        };
    }
}
