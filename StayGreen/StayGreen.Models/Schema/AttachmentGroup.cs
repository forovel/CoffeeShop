using StayGreen.Models.Common;
using System;

namespace StayGreen.Models.Schema
{
    public class AttachmentGroup : NamedEntity<Guid>
    {
        public string Description { get; set; }
    }
}
