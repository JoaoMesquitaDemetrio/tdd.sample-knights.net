namespace Sample.Utils.Extensions;

public static class NumberExtensions
{
    public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
        => (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
}
