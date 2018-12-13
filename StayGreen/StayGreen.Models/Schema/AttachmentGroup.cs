using StayGreen.Models.Enums;
using StayGreen.Models.Schema.Common;
using System;
using System.Collections.Generic;

namespace StayGreen.Models.Schema
{
    public class AttachmentGroup : NamedEntity<Guid>
    {

        public FileCategoryType CategoryType { get; set; }
        public string Description { get; set; }

        //Reverse navigation
        public virtual ICollection<Attachment> Attachments { get; set; }

        public AttachmentGroup()
        {
            Attachments = new List<Attachment>();
        }
    }
}
