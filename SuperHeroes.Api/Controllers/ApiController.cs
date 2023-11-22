
using Infinite.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net;

namespace Infinite.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponse(HttpStatusCode status, object result = null)
        {
            return StatusCode((int)status, new
            {
                statusCode = status,
                data = result,
                errors = _errors
            });
        }

        protected ActionResult CustomResponse<T>(ServiceResponse<T> result)
        {
            return StatusCode((int)result.StatusCode, result);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string error)
        {
            _errors.Add(error);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }

    }
}
