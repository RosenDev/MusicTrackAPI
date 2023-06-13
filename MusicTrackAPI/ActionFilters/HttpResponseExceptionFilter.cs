using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicTrackAPI.Model;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace MusicTrackAPI.ActionFilters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is Exception httpResponseException)
            {
                context.Result = new ObjectResult(ApiResponse.InternalServerError(httpResponseException.Message))
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            };

            context.ExceptionHandled = true;
        }
    }
}

