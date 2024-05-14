namespace Sample.Utils.Extensions;

public static class StringExtensions
{
    public static bool IsNullorEmpty(this string value)
        => string.IsNullOrEmpty(value);

    public static string ToSnakeCase(this string str)
    {
        return string.Concat(str.Select((character, index) =>
                index > 0 && char.IsUpper(character)
                    ? "_" + character
                    : character.ToString()))
                .ToLower();
    }
}
