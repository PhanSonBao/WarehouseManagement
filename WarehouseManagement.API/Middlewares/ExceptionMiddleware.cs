using FluentValidation;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        switch (ex)
        {
            case ValidationException validationException:
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Validation Error",
                    details = validationException.Errors.Select(d => new
                    {
                        d.PropertyName,
                        d.ErrorMessage,
                    })
                });
                break;
            case NotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = ex.Message
                });
                break;
            case DomainException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = ex.Message
                });
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Internal Server Error " + ex.Message
                });
                break;
        }
    }
}