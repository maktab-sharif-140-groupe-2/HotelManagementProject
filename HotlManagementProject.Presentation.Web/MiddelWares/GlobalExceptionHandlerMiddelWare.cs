using HotelManagementProject.Domain.Abstraction;
using HotelManagementProject.Domain.Common;
using HotelMangement_Service.Exceptions;
using HotlManagementProject.Presentation.Web.ResultPattern;
using System.Text.Json;

namespace HotlManagementProject.Presentation.Web.MiddelWares;

public class GlobalExceptionHandlerMiddelWare : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await ExceptionHandler(ex, context);
        }
    }

    private async Task ExceptionHandler(Exception exception, HttpContext context)
    {
        switch (exception)
        {
            case DomainException domainException:
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                await context.Response.WriteAsync(GenerateResponseBody(domainException.Message, domainException.Code));
                break;

            case DouplicateException douplicateException:
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(GenerateResponseBody(douplicateException.Message, douplicateException.Code));
                break;

            case NotFoundException notFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(GenerateResponseBody(notFoundException.Message, notFoundException.Code));
                break;

            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(GenerateResponseBody("Some things don't work right.", "InternalException_500"));
                break;
        }
    }

    private string GenerateResponseBody(string message, string code)
    {
        var erorr = new ErrorModel(message, code);

        var result = Result.Failure(erorr);

        return JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

    }
}
