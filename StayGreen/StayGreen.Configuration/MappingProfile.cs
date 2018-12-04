using AutoMapper;
using StayGreen.Models.Dtos;
using StayGreen.Models.Schema;

namespace StayGreen.Configuration
{
    public static class MappingProfile
    {
        public static void InitMappingProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
            });
        }
    }
}
