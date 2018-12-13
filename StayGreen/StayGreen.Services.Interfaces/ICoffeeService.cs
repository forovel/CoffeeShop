﻿using StayGreen.Models.Schema;
using StayGreen.Services.Interfaces.Common;
using System;

namespace StayGreen.Services.Interfaces
{
    public interface ICoffeeService : IBaseService<Coffee, Coffee, Coffee, Guid>
    {
    }
}
