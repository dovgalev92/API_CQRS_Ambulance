
namespace Ambulance_API_CQRS.Midlleware
{
    public static class CustomExceptionHandlerMiddlewareExctensions
    {
        public static IApplicationBuilder UseCustomeExceptionHandler(this IApplicationBuilder application)
        {
            return application.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}
