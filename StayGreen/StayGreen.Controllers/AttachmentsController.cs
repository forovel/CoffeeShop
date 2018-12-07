using Microsoft.AspNetCore.Mvc;
using StayGreen.Controllers.Common;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace StayGreen.Controllers
{
    public class AttachmentsController : BaseApiController
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentsController(
            IAttachmentService attachmentService
            )
        {
            _attachmentService = attachmentService;
        }

        [Route("/Upload")]
        [HttpPost]
        public async Task<IActionResult> UploadFile(Guid attachmentGroupId)
        {
            var file = Request.Form.Files[0];
            if (file != null)
            {
                AttachmentDto attachment;
                try
                {
                    attachment = await _attachmentService.UploadFileLocal(file, attachmentGroupId);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(attachment);
            }

            return BadRequest();
        }

        [Route("/Download")]
        [HttpGet("download")]
        public void DownloadFile(Guid attachmentId)
        {

        }
    }
}
