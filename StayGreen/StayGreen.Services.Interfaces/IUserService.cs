using StayGreen.Models.Dtos.Schemas;
using StayGreen.Services.Interfaces.Common;
using System;

namespace StayGreen.Services.Interfaces
{
    public interface IUserService : IBaseService<UserDto, UserDto, UserDto, Guid>
    {
    }
}
