using Schoolhub.Application.Common;
using Schoolhub.Domain.Classes;

namespace Schoolhub.API.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notFound.Message);
        }
        catch (InvalidOperationException invalidOperation)
        {
            context.Response.StatusCode = 409;
            await context.Response.WriteAsync(invalidOperation.Message);
        }
        catch (StudentAlreadyInClassException alreadyInClassException)
        {
            context.Response.StatusCode = 409;
            await context.Response.WriteAsync(alreadyInClassException.Message);
        }
        catch (ClassIsFullException classIsFullException)
        {
            context.Response.StatusCode = 409;
            await context.Response.WriteAsync(classIsFullException.Message);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}