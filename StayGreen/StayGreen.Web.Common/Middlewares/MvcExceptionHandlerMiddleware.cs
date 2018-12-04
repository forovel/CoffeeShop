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
        private MvcResponse _response;

        public MvcExceptionHandlerMiddleware(
            RequestDelegate next,
            IOptions<AppSettings> options,
            MvcResponse response
            )
        {
            _next = next;
            _options = options;
            _response = response;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                _response.ShowResponse = false;

                HttpNotFoundPageExeptionGeneration(context);
            }
            catch (StayGreenException ex)
            {
                GenerateDeveloperResponse(ex);
                TemporaryRedirect(context);
            }
            catch (Exception ex)
            {
                GenerateResponse();
                TemporaryRedirect(context);
            }
        }

        private HttpContext TemporaryRedirect(HttpContext context)
        {
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
                GenerateNotFoundResponse();
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

        private void GenerateResponse()
        {
            _response.ErrorCode = 1;
            _response.StatusCode = (int)HttpStatusCode.BadRequest;
            _response.UserMessage = "Something bad happened";
            _response.DeveloperMessage = null;
            _response.ShowResponse = true;
        }

        private void GenerateNotFoundResponse()
        {
            _response.ErrorCode = 2;
            _response.StatusCode = (int)HttpStatusCode.NotFound;
            _response.UserMessage = "Page not found";
            _response.DeveloperMessage = null;
            _response.ShowResponse = true;
        }

        private void GenerateDeveloperResponse(StayGreenException ex)
        {
            _response.ErrorCode = ex.ErrorCode;
            _response.StatusCode = ex.StatusCode;
            _response.UserMessage = ex.UserMessage;
            _response.DeveloperMessage = ex.Message;
            _response.ShowResponse = true;
        }
    }
}
