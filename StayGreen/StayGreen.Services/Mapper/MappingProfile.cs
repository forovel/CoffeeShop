using AutoMapper;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Schema;

namespace StayGreen.Services
{
    public static class MappingProfile
    {
        public static void InitMappingProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();

                cfg.CreateMap<Attachment, AttachmentDto>();
                cfg.CreateMap<AttachmentDto, Attachment>();
            });
        }
    }
}
