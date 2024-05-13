using MongoDB.Driver.Linq;
using Sample.Knights.Core.Domain.Entities.Knight;

namespace Sample.Knights.Core.Domain.Filters;

public class KnightFilters
{
    public bool? Heroes { get; set; }

    public KnightFilters() { }

    public IMongoQueryable<Knight> Apply(IMongoQueryable<Knight> query) 
    {
        if (Heroes.HasValue)
            query = query.Where(x => x.Removed == Heroes.Value);

        return query;
    }
}