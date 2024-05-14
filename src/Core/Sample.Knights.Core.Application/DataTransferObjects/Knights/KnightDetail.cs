using Sample.Knights.Core.Domain.Enums;
using Sample.Utils.Extensions;
using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record KnightDetail(
    string Id,
    string Name,
    string Nickname,
    DateTime Birthday,
    AttributesDetail Attributes,
    List<WeaponDetail> Weapons, 
    TypeAttribute KeyAttribute) 
{ 
    public KnightDetail(Knight knight) : this(
        knight.Id,
        knight.Name,
        knight.Nickname,
        knight.Birthday,
        knight.Attributes.IsNotNull() ? new AttributesDetail(knight.Attributes) : null,
        knight.Weapons?.Select(w => new WeaponDetail(w))?.ToList() ?? new List<WeaponDetail>(),
        knight.KeyAttribute
    ) { }
}
