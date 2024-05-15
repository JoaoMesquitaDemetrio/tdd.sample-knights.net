using Sample.Knights.Core.Domain.Enums;
using Sample.Knights.Core.Domain.Entities.Knights;
using Sample.Utils.Extensions;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record KnightResume(
    string Name, 
    int Age, 
    int Weapons, 
    TypeAttribute Attribute,
    int Attack,
    double Experience)
{
    public string AttributeDescription => 
        Attribute.GetDescription();

    public KnightResume(Knight knight) : this(
        knight.Name,
        knight.GetAge(),
        knight.Weapons?.Count() ?? 0,
        knight.KeyAttribute,
        knight.GetAttack(),
        knight.GetExperience()
    ) { }
}
