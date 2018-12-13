using StayGreen.Common.Query;
using StayGreen.Models.Context;
using StayGreen.Models.Schema;
using StayGreen.Services.Common;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System;

namespace StayGreen.Services
{
    public class CoffeePreparationService : BaseService<CoffeePreparation, CoffeePreparation, CoffeePreparation, CoffeePreparation>, ICoffeePreparationService
    {
        public CoffeePreparationService(
            ApplicationDbContext dbContext,
            IUserWrapper userWrapper
            ) : base(dbContext, userWrapper)
        {

        }

        public override PaginatedList<CoffeePreparation> GetFiltered(IQueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }
    }
}
