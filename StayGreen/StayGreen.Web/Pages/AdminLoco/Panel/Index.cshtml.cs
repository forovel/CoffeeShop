using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StayGreen.Web.Pages.AdminLoco.Panel
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}