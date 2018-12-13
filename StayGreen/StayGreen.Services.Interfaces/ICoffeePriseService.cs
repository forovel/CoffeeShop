using StayGreen.Models.Schema;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayGreen.Services.Interfaces
{
    public interface ICoffeePriseService : IBaseService<CoffeePrise, CoffeePrise, CoffeePrise, Guid>
    {
        Task<IEnumerable<CoffeePrise>> CreateMany(IEnumerable<CoffeePrise> coffeePrises);
    }
}
