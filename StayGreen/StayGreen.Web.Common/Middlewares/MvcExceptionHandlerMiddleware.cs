using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using StayGreen.Common.Exception;
using StayGreen.Common.Settings;
using StayGreen.Web.Common.Helpers;
using System;
using System.Globalization;
using System.Net;
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
                HttpNotFoundPageExeptionGeneration(context);
            }
            catch (StayGreenException ex)
            {
                var responseMessage = GenerateDeveloperResponse(ex);
                TemporaryRedirect(context, responseMessage);
            }
            catch (Exception ex)
            {
                var responseMessage = GenerateResponse();
                TemporaryRedirect(context, responseMessage);
            }
        }

        private Response GenerateResponse()
        {
            var resp = new Response
            {
                ErrorCode = 1,
                StatusCode = 400,
                UserMessage = "Something bad happened"
            };

            return resp;
        }

        private Response GenerateDeveloperResponse(StayGreenException ex)
        {
            var resp = new DeveloperResponse
            {
                ErrorCode = ex.ErrorCode,
                StatusCode = ex.StatusCode,
                UserMessage = ex.UserMessage,
                DeveloperMessage = ex.Message
            };

            return resp;
        }

        private HttpContext TemporaryRedirect(HttpContext context, Response response)
        {
            var currentPath = context.Request.Path.Value;
            string newPath = ReturnOfPathErorPage(context);

            context.Response.Redirect(newPath);

            return context;
        }

        private void HttpNotFoundPageExeptionGeneration(HttpContext context)
        {
            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                string path = ReturnOfPathErorPage(context);
                context.Response.Redirect(path);
            }
        }

        private string ReturnOfPathErorPage(HttpContext context)
        {
            string newPath;

            if (context.Request.Path.Value.Contains("/AdminLoco/"))
            {
                var errorPath = "/AdminLoco/Error";
                newPath = new PathString(string.Format(CultureInfo.InvariantCulture, errorPath));
            }
            else
            {
                var errorPath = "/Error";
                newPath = new PathString(string.Format(CultureInfo.InvariantCulture, errorPath));
            }

            return newPath;
        }
    }
}
