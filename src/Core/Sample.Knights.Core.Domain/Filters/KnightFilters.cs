using MongoDB.Driver.Linq;
using Sample.Knights.Core.Domain.Constants;
using Sample.Knights.Core.Domain.Entities.Knights;
using Sample.Utils.Extensions;

namespace Sample.Knights.Core.Domain.Filters;

public class KnightFilters
{
    public bool Heroes { get; set; }

    public KnightFilters() { }
    public KnightFilters(string filter) : this()
        => Heroes = filter.IsNullorEmpty() 
            ? false 
            : filter.ToLower() == AppConstants.FILTER_HEROES;
    
    public IMongoQueryable<Knight> Apply(IMongoQueryable<Knight> query) 
    {
        query = query.Where(x => x.Removed == Heroes);

        return query;
    }
}
