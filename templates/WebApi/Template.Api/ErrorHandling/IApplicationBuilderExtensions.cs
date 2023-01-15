using Microsoft.AspNetCore.Mvc;
using System.Net;
using Template.Api.Resources;

namespace Template.Api.ErrorHandling
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandler<T>(this IApplicationBuilder app)
            where T : IConvertToProblemDetails<Exception>
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    var details = GetDetailsForException<T>(ex, app.ApplicationServices);
                    details.Instance = context.Request.Path;

                    await context.ExecuteResultAsync((HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), details.Status), details);
                }
            });

            return app;
        }

        #region internal helpers
        private static ProblemDetails GetDetailsForException<T>(Exception ex, IServiceProvider services)
            where T : IConvertToProblemDetails<Exception>
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));
            if (services == null) throw new ArgumentNullException(nameof(services));

            try
            {
                var handler = (T)services.GetService(typeof(T));
                if (handler == null)
                {
                    return new ProblemDetails
                    {
                        Title = ApiResources.InternalServerErrorTitle,
                        Detail = string.Format(ApiResources.UnregisteredClassTypeFormat, typeof(T)),
                        Status = (int)HttpStatusCode.InternalServerError
                    };
                }

                return handler.ToProblemDetails(ex);
            }
            catch (Exception)
            {
                return new ProblemDetails
                {
                    Title = ApiResources.InternalServerErrorTitle,
                    Detail = ApiResources.InternalServerErrorDesc,
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
        }
        #endregion
    }
}
