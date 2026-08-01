using System.Net;
using System.Text.Json;


namespace EmployeeManagement.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        //RequestDelegate is a delegate that points to the next middleware in the pipeline.
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //This is the entry point of every middleware.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } 
            catch (Exception ex)
            {

                await HandleExceptionAsync(context,ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception exception) 
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            //Convert object to JSON
            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
