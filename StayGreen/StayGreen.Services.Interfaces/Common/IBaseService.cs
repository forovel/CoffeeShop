using StayGreen.Common.Query;
using System.Threading.Tasks;

namespace StayGreen.Services.Interfaces.Common
{
    public interface IBaseService<TReadDto, TCreateDto, TUpdateDto, in TId>
    {
        PaginatedList<TReadDto> GetFiltered(IQueryOptions queryOptions);

        Task<TCreateDto> Create(TCreateDto model);

        Task<TUpdateDto> Update(TId id, TUpdateDto model);

        TReadDto GetById(TId id);

        Task Delete(TId id);
    }
}
