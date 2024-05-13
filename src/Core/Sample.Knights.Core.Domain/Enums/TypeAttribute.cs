using System.ComponentModel;

namespace Sample.Knights.Core.Domain.Enums;

public enum TypeAttribute
{
    [Description("Strength")]
    STRENGTH = 1,

    [Description("Dexterity")]
    DEXTERITY = 2,

    [Description("Constitution")]
    CONSTITUTION = 3,

    [Description("Intelligence")]
    INTELLIGENCE = 4,

    [Description("Wisdom")]
    WISDOM = 5,

    [Description("Charisma")]
    CHARISMA = 6
}
