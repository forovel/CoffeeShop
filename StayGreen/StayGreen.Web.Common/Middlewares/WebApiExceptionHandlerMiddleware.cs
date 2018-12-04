using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StayGreen.Common.Exception;
using StayGreen.Common.Settings;
using StayGreen.Web.Common.Helpers;
using System;
using System.IO;
using System.Text;
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
            catch (StayGreenException ex)
            {
                var responseMessage = CreateResponse(ex);
                await GenerateResponseObjectAsync(context, responseMessage);

            }
            catch (Exception ex)
            {
                var responseMessage = CreateBaseResponse();
                await GenerateResponseObjectAsync(context, responseMessage);
            }
        }

        private Response CreateBaseResponse()
        {
            //var apiUrl = $"{_appSettings.ApiUrlPrefix["Api"]}/{_appSettings.ApiUrlPrefix["Version"]}/" + 1;
            var resp = new Response()
            {
                ErrorCode = 1,
                //MoreInfo = apiUrl,
                StatusCode = 400,
                UserMessage = "Something bad happened"
            };

            return resp;
        }

        private Response CreateResponse(StayGreenException ex)
        {
            //var apiUrl = $"{_appSettings.ApiUrlPrefix["Api"]}/{_appSettings.ApiUrlPrefix["Version"]}";

            var resp = new DeveloperResponse
            {
                DeveloperMessage = ex.Message,
                ErrorCode = ex.ErrorCode,
                //MoreInfo = apiUrl,
                StatusCode = ex.StatusCode,
                UserMessage = ex.UserMessage
            };

            return resp;
        }

        private Task GenerateResponseObjectAsync(HttpContext context, Response message)
        {
            var body = new MemoryStream();
            var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            body.Write(buffer, 0, buffer.Length);
            body.Position = 0;

            context.Response.Headers.Add("Content-Type", "application/json");
            context.Response.StatusCode = message.StatusCode.Value;

            return body.CopyToAsync(context.Response.Body);
        }
    }
}
