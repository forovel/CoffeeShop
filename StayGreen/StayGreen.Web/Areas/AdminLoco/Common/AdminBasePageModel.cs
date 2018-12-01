using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StayGreen.Web.Areas.AdminLoco.Common
{
    [Authorize]
    public class AdminBasePageModel : PageModel
    {
    }
}
