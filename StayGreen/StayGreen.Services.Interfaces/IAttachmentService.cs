using Microsoft.AspNetCore.Http;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Threading.Tasks;

namespace StayGreen.Services.Interfaces
{
    public interface IAttachmentService : IBaseService<AttachmentDto, AttachmentDto, AttachmentDto, Guid>
    {
        Task<AttachmentDto> UploadFileLocal(IFormFile file, Guid attachmentGroupId);
    }
}
