using Sample.Knights.Core.Domain.Enums;
using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record WeaponDetail(
    string Id,
    string Name,
    int Mod,
    TypeAttribute TypeAttribute,
    bool Equipped) 
{ 
    public WeaponDetail(Weapon weapon) : this(
        weapon.Id,
        weapon.Name,
        weapon.Mod,
        weapon.TypeAttribute,
        weapon.Equipped
    ) { }
}
