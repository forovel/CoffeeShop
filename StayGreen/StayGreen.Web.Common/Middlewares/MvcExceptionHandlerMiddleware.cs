using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using StayGreen.Common.Exception;
using StayGreen.Common.Settings;
using System;
using System.Threading.Tasks;

namespace StayGreen.Web.Common.Middlewares
{
    public class MvcExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AppSettings> _options;

        public MvcExceptionHandlerMiddleware(
            RequestDelegate next,
            IOptions<AppSettings> options
            )
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (StayGreenException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
