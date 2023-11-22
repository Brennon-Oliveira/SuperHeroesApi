using System.Net;

namespace Infinite.Application.Services
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
