using StayGreen.Models.Dtos.Common;
using System;

namespace StayGreen.Models.Dtos.Schemas
{
    public class AttachmentDto : NamedBaseDto<Guid>
    {
        public string Description { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
    }
}
