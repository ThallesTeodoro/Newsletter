using System.Net;
using Newsletter.Api.Contracts;
using Newsletter.Application.Exceptions;

namespace Newsletter.Api.Middlewares;

internal sealed class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandlerExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandlerExceptionAsync(HttpContext httpContext, Exception exception)
    {
        (int statusCode, JsonResponse<object, object> response) statusCodeAndResponse = GetStatusCodeAndResponse(exception);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCodeAndResponse.statusCode;

        await httpContext.Response.WriteAsync(statusCodeAndResponse.response.ToString());
    }

    private (int statusCode, JsonResponse<object, object> response) GetStatusCodeAndResponse(Exception exception)
        => exception switch
        {
            ValidatorException validatorException => (StatusCodes.Status422UnprocessableEntity, new JsonResponse<object, object>(StatusCodes.Status422UnprocessableEntity, null, validatorException.Errors)),
            _ => (StatusCodes.Status500InternalServerError, new JsonResponse<object, object>(StatusCodes.Status500InternalServerError, null, null))
        };
}
