using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StayGreen.Web.Common.Helpers;
using System.Diagnostics;

namespace StayGreen.Web.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        private readonly MvcResponse _response;

        public ErrorModel(MvcResponse response)
        {
            _response = response;
        }

        [BindProperty]
        public ResponseModel ResponseObject { get; set; }

        public class ResponseModel
        {
            public int? ErrorCode { get; set; }
            public int? StatusCode { get; set; }
            public string UserMessage { get; set; }
            public string MoreInfo { get; set; }

            public bool ShowResponse { get; set; }

            public string DeveloperMessage { get; set; }
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            ResponseObject = new ResponseModel
            {
                StatusCode = _response.StatusCode,
                ErrorCode = _response.ErrorCode,
                UserMessage = _response.UserMessage,
                MoreInfo = _response.MoreInfo,
                ShowResponse = _response.ShowResponse,
                DeveloperMessage = _response.DeveloperMessage
            };

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
