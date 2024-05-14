using Sample.Knights.Core.Domain.Enums;
using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record WeaponInsert(
    string Name,
    int Mod,
    TypeAttribute TypeAttribute,
    bool Equipped) : BaseModel<Weapon>
{
    public override Weapon TransferTo()
    {
        return new Weapon
        {
            Name = Name,
            Mod = Mod,
            TypeAttribute = TypeAttribute,
            Equipped = Equipped
        };
    }

    public override void UpdateEntity(Weapon entity)
    {
        entity.Name = Name;
        entity.Mod = Mod;
        entity.TypeAttribute = TypeAttribute;
        entity.Equipped = Equipped;
    }
}
