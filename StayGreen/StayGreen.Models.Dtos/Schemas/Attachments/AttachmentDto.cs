using StayGreen.Models.Dtos.Common;

namespace StayGreen.Models.Dtos.Schemas
{
    public class AttachmentDto : NamedBaseDto
    {
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
