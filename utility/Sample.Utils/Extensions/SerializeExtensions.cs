using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Sample.Utils.Extensions;

public static class SerializeExtensions
{
    public static void SetDefaultJsonSerializerSettings(this JsonSerializerSettings settings)
    {
        settings.NullValueHandling = NullValueHandling.Ignore;
        settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
        settings.FloatParseHandling = FloatParseHandling.Double;
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
        settings.Culture = new CultureInfo("en-US");
        settings.Converters.Add(new StringEnumConverter());
        settings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() };
    }

    public static JsonSerializerSettings GetDefaultJsonSerializerSettings()
    {
        var settings = new JsonSerializerSettings();
        settings.SetDefaultJsonSerializerSettings();
        return settings;
    }
}
