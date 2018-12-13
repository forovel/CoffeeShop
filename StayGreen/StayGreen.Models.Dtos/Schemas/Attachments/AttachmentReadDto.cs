using StayGreen.Models.Dtos.Common;
using System;

namespace StayGreen.Models.Dtos.Schemas.Attachments
{
    public class AttachmentReadDto : NamedBaseDto<Guid>
    {
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
