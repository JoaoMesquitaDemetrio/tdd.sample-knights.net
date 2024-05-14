using Sample.Knights.Core.Domain.Enums;
using Sample.Utils.Extensions;

namespace Sample.Knights.Core.Domain.Entities.Knights;

public class Attributes
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }

    public Attributes() { }

    public int GetValueFromAttribute(TypeAttribute KeyAttribute) 
    {
        var attributeDescription = KeyAttribute.GetDescription();
        var attributeInfo = this.GetType().GetProperties()
            .FirstOrDefault(p => p.Name == attributeDescription);

        var result = attributeInfo?.GetValue(this) as int?;
        return result.GetValueOrDefault();
    }

    public int GetModFromAttribute(TypeAttribute KeyAttribute) 
    {
        return GetValueFromAttribute(KeyAttribute) switch
        {
            var cond when cond.IsBetween(0, 8) => -2,
            var cond when cond.IsBetween(9, 10) => -1,
            var cond when cond.IsBetween(11, 12) => 0,
            var cond when cond.IsBetween(13, 15) => 1,
            var cond when cond.IsBetween(16, 18) => 2,
            var cond when cond.IsBetween(19, 20) => 3,
            _ => 0
        };
    }
}
