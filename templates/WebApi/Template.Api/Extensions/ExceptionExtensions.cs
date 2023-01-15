using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Template.Api.Extensions
{
    public static class ExceptionExtensions
    {
        public static ProblemDetails ToProblemDetails(this Exception exception, string title, HttpStatusCode statusCode)
        {
            return new ProblemDetails
            {
                Title = title,
                Status = (int)statusCode,
                Detail = exception.Message,
                //Instance = 
            };
        }
    }
}
