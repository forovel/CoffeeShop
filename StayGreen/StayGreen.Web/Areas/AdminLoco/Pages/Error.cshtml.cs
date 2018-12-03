using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace StayGreen.Web.Areas.AdminLoco.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet(int? statusCode = 0)
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            //RequestId = statusCode.ToString();
        }
    }
}