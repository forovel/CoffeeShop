using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using StayGreen.Common.Settings;
using System.Threading.Tasks;

namespace StayGreen.Web.Common.Middlewares
{
    public class WebApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AppSettings> _options;

        public WebApiExceptionHandlerMiddleware(
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
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
