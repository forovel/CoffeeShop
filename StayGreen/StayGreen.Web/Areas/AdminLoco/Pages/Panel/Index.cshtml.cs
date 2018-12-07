using StayGreen.Services.Interfaces;
using StayGreen.Web.Areas.AdminLoco.Common;

namespace StayGreen.Web.Areas.AdminLoco.Pages.Panel
{
    public class IndexModel : AdminBasePageModel
    {
        private readonly IUserWrapper _userWrapper;

        public IndexModel(IUserWrapper userWrapper)
        {
            _userWrapper = userWrapper;
        }

        public void OnGet()
        {
        }
    }
}