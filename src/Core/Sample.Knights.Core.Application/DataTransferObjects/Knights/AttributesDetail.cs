using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record AttributesDetail(
    int Strength,
    int Dexterity,
    int Intelligence,
    int Constitution,
    int Charisma) 
{
    public AttributesDetail(Attributes attributes) : this(
        attributes.Strength,
        attributes.Dexterity,
        attributes.Intelligence,
        attributes.Constitution,
        attributes.Charisma
    ) { }
}
