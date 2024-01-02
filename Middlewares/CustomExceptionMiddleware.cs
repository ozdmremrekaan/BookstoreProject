using Newtonsoft.Json;
using System.Net;
using ILogger = PatikaAkbankBookstore.Services.ILogger;

namespace PatikaAkbankBookstore.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        
        public CustomExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var message = "[Request] HTTP " + context.Request.Method + context.Request.Path;
                _logger.Log(message);
                await _next(context);

                message = "[Response] HTTP " + context.Request.Method + context.Request.Path + " responded " + context.Response.StatusCode;
                _logger.Log(message);

            }catch(Exception ex)
            {
                await HandleException(context, ex);
            }
           
        }
        private Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Error HTTP "+ context.Request.Method + context.Response.StatusCode + "Error Message : " + ex.Message;
            _logger.Log(message);

            var result = JsonConvert.SerializeObject(new { error = message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomEsceptionMiddle(this IApplicationBuilder builder) {
            
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
