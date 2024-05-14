namespace Sample.Utils.Extensions;

public static class ObjectExtensions
{
    public static bool IsNull(this object value)
        => value == null;

    public static bool IsNotNull(this object value)
        => value != null;
    
    public static bool IsNullorEmpty<T>(this IEnumerable<T> value)
        => value == null || value.ToList().Count <= 0;
    
    public static IEnumerable<T> GetValueOrDefault<T>(this IEnumerable<T> items)
        => items ?? new List<T>();

    public static decimal AsDecimal(this object item, decimal defaultDecimal = default)
    {
        if (item == null)
            return defaultDecimal;

        if (!decimal.TryParse(item.ToString(), out decimal result))
            return defaultDecimal;

        return result;
    }

    public static int AsInt(this object item, int defaultInt = default)
    {
        if (item == null)
            return defaultInt;

        int result;

        if (item is Enum)
            result = Convert.ToInt32(item);
        else if (!int.TryParse(item.ToString(), out result))
            result = defaultInt;

        return result;
    }

    public static Guid AsGuid(this object item)
    {
        try { return new Guid(item.ToString()); }
        catch { return Guid.Empty; }
    }
}
