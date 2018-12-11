using System;

namespace StayGreen.Models.Schema
{
    public class AttachmentCoffee
    {
        public Guid CoffeeId { get; set; }
        public Guid AttachmentId { get; set; }

        //Foreign keys
        public virtual Attachment Attachment { get; set; }
        public virtual Coffee Coffee { get; set; }
    }
}
