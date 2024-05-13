using Sample.Knights.Core.Domain.Entities.Knight;
using Sample.Knights.Test.Shared.Utils;

namespace Sample.Knights.Test.Shared.Fixtures.Entities;

public sealed class AttributesFixture
{
    public AttributesFixture() { }

    public static Attributes CreateAtributtes()
    {
        return new Attributes
        {
            Strength = Extensions.RandomIntegerBetween(1, 20),
            Dexterity = Extensions.RandomIntegerBetween(1, 20),
            Constitution = Extensions.RandomIntegerBetween(1, 20),
            Intelligence = Extensions.RandomIntegerBetween(1, 20),
            Wisdom = Extensions.RandomIntegerBetween(1, 20),
            Charisma = Extensions.RandomIntegerBetween(1, 20)
        };
    }
}
