using StayGreen.Models.Common;
using System;

namespace StayGreen.Models.Schema
{
    public class Attachment : NamedEntity<Guid>
    {
        public string Description { get; set; }
        public string Path { get; set; }

        public virtual AttachmentGroup AttachmentGroup { get; set; }
    }
}
