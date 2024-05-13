using Sample.Knights.Core.Domain.Entities.Knight;
using Sample.Knights.Core.Domain.Filters;

namespace Sample.Knights.Core.Domain.Interfaces;

public interface IKnightService : IDataQueryService<Knight>
{
    public Task<IEnumerable<Knight>> GetWithFilters(KnightFilters filters);
}
