using StayGreen.Common.Query;
using StayGreen.Models.Context;
using StayGreen.Models.Dtos.Schemas.Coffee;
using StayGreen.Models.Schema;
using StayGreen.Services.Common;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System.Threading.Tasks;

namespace StayGreen.Services
{
    public class CoffeeService : BaseService<Coffee, CoffeeReadDto, Coffee, Coffee>, ICoffeeService
    {
        private readonly ICoffeePriseService _coffeePriseService;

        public CoffeeService(
            ApplicationDbContext dbContext,
            IUserWrapper userWrapper,
            ICoffeePriseService coffeePriseService
            ) 
            : base(dbContext, userWrapper)
        {
            _coffeePriseService = coffeePriseService;
        }

        public override async Task<Coffee> Create(Coffee model)
        {
            return await base.Create(model);
        }

        public override PaginatedList<CoffeeReadDto> GetFiltered(IQueryOptions queryOptions)
        {
            throw new System.NotImplementedException();
        }
    }
}
