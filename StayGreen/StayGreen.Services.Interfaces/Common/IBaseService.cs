using StayGreen.Common.Query;
using System.Linq;

namespace StayGreen.Services.Interfaces.Common
{
    public interface IBaseService<TReadDto, TCreateDto, TUpdateDto, in TId>
    {
        PaginatedList<TReadDto> GetFiltered(IQueryOptions queryOptions);

        TCreateDto Create(TCreateDto model);

        TUpdateDto Update(TId id, TUpdateDto model);

        TReadDto GetById(TId id);

        void Delete(TId id);
    }
}
