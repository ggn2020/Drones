using System.Net;

namespace Drones.Application.Common.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Success = true;
            Code = HttpStatusCode.OK;
        }
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
