using StayGreen.Common.Query;
using StayGreen.Models.Context;
using StayGreen.Models.Schema;
using StayGreen.Services.Common;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayGreen.Services
{
    public class CoffeePriseService : BaseService<CoffeePrise, CoffeePrise, CoffeePrise, CoffeePrise>, ICoffeePriseService
    {
        public CoffeePriseService(
            ApplicationDbContext dbContext,
            IUserWrapper userWrapper
            ) : base(dbContext, userWrapper)
        {

        }

        public async Task<IEnumerable<CoffeePrise>> CreateMany(IEnumerable<CoffeePrise> coffeePrises)
        {
            List<CoffeePrise> createdCoffeePrises = new List<CoffeePrise>();

            foreach (var coffeePrise in coffeePrises)
            {
                var createdCoffeePrise = await base.Create(coffeePrise);
                createdCoffeePrises.Add(createdCoffeePrise);
            }

            return createdCoffeePrises;
        }

        public override PaginatedList<CoffeePrise> GetFiltered(IQueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }
    }
}
