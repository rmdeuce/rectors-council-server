using Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            // TODO: логгирование
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (e)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break; 
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
                result = JsonSerializer.Serialize(new { error = e.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
