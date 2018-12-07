using StayGreen.Common.Query;
using StayGreen.Models.Context;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Schema;
using StayGreen.Services.Common;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;

namespace StayGreen.Services
{
    public class UserService : BaseService<User, UserDto, UserDto, UserDto>, IUserService
    {
        private readonly ISecurityService _securityService;

        public UserService(
            ApplicationDbContext dbContext,
            IUserWrapper userWrapper, 
            ISecurityService securityService
            )
            : base(dbContext, userWrapper)
        {
            _securityService = securityService;
        }

        public override PaginatedList<UserDto> GetFiltered(IQueryOptions queryOptions)
        {
            throw new System.NotImplementedException();
        }
    }
}
