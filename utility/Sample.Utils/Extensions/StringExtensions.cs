namespace Sample.Utils.Extensions;

public static class StringExtensions
{
    public static bool IsNullorEmpty(this string value)
        => string.IsNullOrEmpty(value);
}
