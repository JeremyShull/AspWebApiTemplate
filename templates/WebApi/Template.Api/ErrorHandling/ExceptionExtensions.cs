using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Template.Api.ErrorHandling
{
    public static class ExceptionExtensions
    {
        public static ProblemDetails ToProblemDetails(this Exception ex, HttpStatusCode status, string title)
        {
            return new ProblemDetails
            {
                Title = title,
                Status = (int)status,
                Detail = ex.Message
            };
        }
    }
}
