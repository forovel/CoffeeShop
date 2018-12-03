using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using StayGreen.Web.Common.Helpers;
using System.Diagnostics;
using System.IO;

namespace StayGreen.Web.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            //Response response;
            //var json = new JsonSerializer();

            //using (var sr = new StreamReader(HttpContext.Request.Body))
            //using (var jsonTextReader = new JsonTextReader(sr))
            //{
            //    response = json.Deserialize<Response>(jsonTextReader);
            //}
            var test = HttpContext.Items["Exception"] as Response;
        }
    }
}
