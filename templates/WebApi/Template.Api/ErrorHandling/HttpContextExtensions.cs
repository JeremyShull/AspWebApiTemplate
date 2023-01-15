using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Template.Api.ErrorHandling
{
    public static class HttpContextExtensions
    {
        private static readonly RouteData EmptyRouteData = new RouteData();
        private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();

        public static Task ExecuteResultAsync<T>(this HttpContext context, HttpStatusCode statusCode, T retObj)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (retObj == null) throw new ArgumentNullException(nameof(retObj));

            var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ObjectResult>>();
            var routeData = context.GetRouteData() ?? EmptyRouteData;
            var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);
            var result = new ObjectResult(retObj) { StatusCode = (int)statusCode };

            return executor.ExecuteAsync(actionContext, result);
        }
    }
}
