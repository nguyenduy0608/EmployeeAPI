using EmployeeAPI.Dtos;

namespace EmployeeAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await httpContext.Response.WriteAsJsonAsync(
                    JsonResponse.Error(0, ex.ToString())
                );
            }
        }
    }
}
