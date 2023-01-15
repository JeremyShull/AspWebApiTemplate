using Microsoft.AspNetCore.Mvc;

namespace Template.Api.ErrorHandling
{
    public interface IConvertToProblemDetails<T>
        where T : class
    {
        ProblemDetails ToProblemDetails(T instance);
    }
}
