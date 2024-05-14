using Sample.Knights.Core.Domain.Entities.Knights;
using Sample.Knights.Core.Domain.Filters;

namespace Sample.Knights.Core.Domain.Interfaces;

public interface IKnightService : IDataManipulationService<Knight>
{
    public Task<IEnumerable<Knight>> GetWithFilters(KnightFilters filters);
}
