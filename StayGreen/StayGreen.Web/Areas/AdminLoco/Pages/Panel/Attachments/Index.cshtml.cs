using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StayGreen.Common.Query;
using StayGreen.Controllers.Code;
using StayGreen.Models.Dtos.Schemas.Attachments;
using StayGreen.Services.Interfaces;
using System.Collections.Generic;

namespace StayGreen.Web.Areas.AdminLoco.Pages.Panel.Attachments
{
    public class IndexModel : PageModel
    {
        private readonly IAttachmentService _attachmentService;

        public IndexModel(
            IAttachmentService attachmentService
            )
        {
            _attachmentService = attachmentService;
        }

        [BindProperty]
        public PaginatedList<AttachmentReadDto> ListAttachments { get; set; }

        public void OnGet([FromQuery] QueryOptions options)
        {
            ListAttachments = _attachmentService.GetFiltered(options);
        }
    }
}