﻿using StayGreen.Models.Dtos.Common;

namespace StayGreen.Models.Dtos.Schemas.Attachments
{
    public class AttachmentReadDto : NamedBaseDto
    {
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
