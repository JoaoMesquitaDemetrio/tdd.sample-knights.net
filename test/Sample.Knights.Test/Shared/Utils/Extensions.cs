using Sample.Utils.Extensions;

namespace Sample.Knights.Test.Shared.Utils;

public class Extensions
{
private static readonly Random _random = new();

    public static string RandomString(int length)
        => Randomize("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length);

    public static string RandomNumericString(int length)
        => Randomize("0123456789", length);

    public static decimal RandomDecimalBetween(double minValue, double maxValue)
    {
        var next = _random.NextDouble();
        var result = minValue + (next * (maxValue - minValue));

        return result.AsDecimal();
    }

    public static int RandomIntegerBetween(double minValue, double maxValue)
    {
        var next = _random.NextInt64();
        var result = minValue + (next * (maxValue - minValue));

        return result.AsInt();
    }

    private static string Randomize(string chars, int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
    
    public static class RandomEmailGenerator
    {
        private static readonly Random random = new();

        private static readonly string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "uol.com", "bol.com", "ig.com", "live.com", "globomail.com", "globo.com", "r7.com", "terra.com", "zipmail.com", "oi.com", "pop.com" };

        public static string RandomEmail()
        {
            string user = $"{RandomString(5)}{RandomString(6)}";
            string domain = domains[random.Next(domains.Length)];

            return $"{user.ToLower()}@{domain}";
        }
    }
}
