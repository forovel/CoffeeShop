using StayGreen.Models.Dtos.Schemas.Coffee;
using StayGreen.Models.Schema;
using StayGreen.Services.Interfaces.Common;
using System;

namespace StayGreen.Services.Interfaces
{
    public interface ICoffeeService : IBaseService<CoffeeReadDto, Coffee, Coffee, Guid>
    {
    }
}
