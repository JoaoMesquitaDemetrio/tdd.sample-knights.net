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
}
