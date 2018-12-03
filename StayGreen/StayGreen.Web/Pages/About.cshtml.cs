using Microsoft.AspNetCore.Mvc.RazorPages;
using StayGreen.Services.Interfaces;

namespace StayGreen.Web.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IEmailService _emailService;

        public AboutModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public string Message { get; set; }

        public void OnGet()
        {
            //Message = "Your application description page.";
            Message = null;
            _emailService.SendEmail();
        }
    }
}
