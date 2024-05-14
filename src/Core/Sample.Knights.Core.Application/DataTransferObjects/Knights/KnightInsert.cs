using Sample.Knights.Core.Domain.Entities.Knights;
using Sample.Knights.Core.Domain.Enums;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record KnightInsert(
    string Name,
    string Nickname,
    DateTime Birthday,
    IEnumerable<WeaponInsert> Weapons,
    AttributesInsert Attributes,
    TypeAttribute KeyAttribute) : BaseModel<Knight>
{
    public override Knight TransferTo()
    {
        var entity = new Knight
        {
            Name = Name,
            Nickname = Nickname,
            Birthday = Birthday,
            Weapons = Weapons.Select(w => w.TransferTo()).ToList(),
            Attributes = Attributes.TransferTo(),
            KeyAttribute = KeyAttribute
        };

        return entity;
    }

    public override void UpdateEntity(Knight entity)
    {
        entity.Name = Name;
        entity.Nickname = Nickname;
        entity.Birthday = Birthday;
        entity.Weapons = Weapons.Select(w => w.TransferTo()).ToList();
        entity.Attributes = Attributes.TransferTo();
        entity.KeyAttribute = KeyAttribute;
    }
}
