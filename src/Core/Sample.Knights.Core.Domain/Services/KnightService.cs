using Sample.Knights.Core.Domain.Interfaces;
using Sample.Knights.Core.Domain.Entities.Knight;
using Sample.Knights.Core.Domain.Interfaces.Repositories;
using Sample.Knights.Core.Domain.Filters;
using MongoDB.Driver;

namespace Sample.Knights.Core.Domain.Services;

public class KnightService(IMongoDBContext context) : DataQueryService<Knight>(context), IKnightService
{
    public async Task<IEnumerable<Knight>> GetWithFilters(KnightFilters filters)
    {
        var query = filters.Apply(BaseQuery());
        return await query.ToListAsync();
    }
}
