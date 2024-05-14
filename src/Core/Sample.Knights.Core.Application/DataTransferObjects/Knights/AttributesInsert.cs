using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record AttributesInsert(
    int Strength,
    int Dexterity,
    int Intelligence,
    int Constitution,
    int Charisma) : BaseModel<Attributes>
{
    public override Attributes TransferTo()
    {
        return new Attributes
        {
            Strength = Strength,
            Dexterity = Dexterity,
            Intelligence = Intelligence,
            Constitution = Constitution,
            Charisma = Charisma
        };
    }

    public override void UpdateEntity(Attributes entity)
    {
        entity.Strength = Strength;
        entity.Dexterity = Dexterity;
        entity.Intelligence = Intelligence;
        entity.Constitution = Constitution;
        entity.Charisma = Charisma;
    }
}
