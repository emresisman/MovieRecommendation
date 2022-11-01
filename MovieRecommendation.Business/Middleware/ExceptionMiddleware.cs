using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MovieRecommendation.Business.Response;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = "";
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    var response = new ErrorResult(message);
                    var json = JsonConvert.SerializeObject(response);
                    await context.Response.WriteAsync(json);
                }
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}