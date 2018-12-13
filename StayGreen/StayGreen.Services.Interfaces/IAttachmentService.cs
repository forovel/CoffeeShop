using Microsoft.AspNetCore.Http;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Dtos.Schemas.Attachments;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayGreen.Services.Interfaces
{
    public interface IAttachmentService : IBaseService<AttachmentReadDto, AttachmentDto, AttachmentDto, Guid>
    {
        Task<AttachmentDto> UploadFileLocal(IFormFile file, Guid attachmentGroupId);
        IEnumerable<AttachmentDto> GetOnlyImages();
    }
}
