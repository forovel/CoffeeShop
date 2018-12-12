using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class Attachment : NamedEntity<Guid>
    {
        public string Description { get; set; }
        public string Path { get; set; }
        public Guid AttachmentGroupId { get; set; }

        //Foreign keys
        public virtual AttachmentGroup AttachmentGroup { get; set; }

        //Reverse navigation
        public virtual ICollection<AttachmentCoffee> AttachmentsCoffee { get; set; }

        public Attachment()
        {
            AttachmentsCoffee = new List<AttachmentCoffee>();
        }
    }
}
