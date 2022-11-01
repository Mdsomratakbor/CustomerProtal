using System.Net;

namespace CustomerInfo.API.DTO
{
    public class ResponseMessage
    {
        public ResponseMessage(HttpStatusCode statusCode, bool status, dynamic message, dynamic data)
        {
            this.Code = statusCode;
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }
        public HttpStatusCode Code { get; }
        public bool Status { get; }
        public dynamic Message { get; }
        public dynamic Data { get; }
    }
}
