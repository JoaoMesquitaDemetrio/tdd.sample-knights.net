using System.ComponentModel;
using System.Reflection;

namespace Sample.Utils.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        DescriptionAttribute attribute = value.GetType()
            .GetField(value.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .SingleOrDefault() as DescriptionAttribute;

        return attribute == null ? value.ToString() : attribute.Description;
    }

    public static T GetEnum<T>(this string description) where T : Enum
    {
        var type = typeof(T);

        FieldInfo[] fields = type.GetFields();

        var field = fields
            .SelectMany(f =>
                f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                (f, a) => new { Field = f, Att = a }
            ).Where(a => ((DescriptionAttribute)a.Att).Description == description).SingleOrDefault();

        return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
    }
}
