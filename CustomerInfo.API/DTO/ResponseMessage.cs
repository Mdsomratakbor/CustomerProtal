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
        private HttpStatusCode Code { get; }
        private bool Status { get; }
        private dynamic Message { get; }
        private dynamic Data { get; }
    }
}
