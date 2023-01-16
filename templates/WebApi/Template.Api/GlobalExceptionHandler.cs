using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Template.Api.ErrorHandling;
using Template.Api.Extensions;
using Template.Api.Resources;

namespace Template.Api
{
    public class GlobalExceptionHandler : IConvertToProblemDetails<Exception>
    {
        private readonly ILogger _logger;
        private readonly bool _isDevelopment = false;

        public GlobalExceptionHandler(ILoggerFactory logFactory,
                                      IWebHostEnvironment env)
        {
            _logger = logFactory.CreateLogger<GlobalExceptionHandler>();
            _isDevelopment = env?.IsDevelopment() ?? false;
        }

        public ProblemDetails ToProblemDetails(Exception ex)
        {
            switch (ex)
            {
                case ValidationException v:
                    _logger?.LogInformation(ex, ex.Message, ex.Data);// GetAllData());
                    return ex.ToProblemDetails(HttpStatusCode.BadRequest, ApiResources.ValidationErrorTitle);
                default:
                    {
                        _logger?.LogError(ex, ex.Message, ex.Data);// GetAllData());

                        var details = ex.ToProblemDetails(
                            HttpStatusCode.InternalServerError, 
                            ApiResources.InternalServerErrorTitle);

                        if (!_isDevelopment)
                            details.Detail = ApiResources.InternalServerErrorDesc;

                        return details;
                    }
            }
        }
    }
}
