using Microsoft.AspNetCore.Builder;
using System;

namespace StayGreen.Web.Common.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseStayGreenMvcExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MvcExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseStayGreenWebApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebApiExceptionHandlerMiddleware>();
        }
    }
}
