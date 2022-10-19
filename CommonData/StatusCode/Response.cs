using System;
namespace CommonData.StatusCode
{
    public class Response
    {
        public Response(int status, string? message)
        {
            Status = status;
            Message = message ?? "This response does not contains message";
        }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}

