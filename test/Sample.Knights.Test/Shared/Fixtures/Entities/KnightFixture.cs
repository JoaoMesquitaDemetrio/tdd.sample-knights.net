using Sample.Knights.Core.Domain.Entities.Knight;
using Sample.Knights.Core.Domain.Enums;
using Sample.Knights.Test.Shared.Utils;

namespace Sample.Knights.Test.Shared.Fixtures.Entities;

public class KnightFixture
{
    public KnightFixture() { }

    public static Knight CreateKnight()
    {
        return new Knight
        {
            Id = Guid.NewGuid().ToString(),
            Name = Extensions.RandomString(500),
            Nickname = Extensions.RandomString(250),
            Birthday = new DateTime(1990, 1, 1),
            Attributes = new Attributes
            {
                Strength = Extensions.RandomIntegerBetween(1, 20),
                Dexterity = Extensions.RandomIntegerBetween(1, 20),
                Constitution = Extensions.RandomIntegerBetween(1, 20),
                Intelligence = Extensions.RandomIntegerBetween(1, 20),
                Wisdom = Extensions.RandomIntegerBetween(1, 20),
                Charisma = Extensions.RandomIntegerBetween(1, 20)
            },

            Removed = false
        };
    }

    public static Knight CreateKnight(TypeAttribute typeAttribute)
    {
        var knight = CreateKnight();
        knight.KeyAttribute = typeAttribute;

        return knight;
    }

    public static Knight CreateKnight(TypeAttribute typeAttribute, IEnumerable<Weapon> weapons)
    {
        var knight = CreateKnight(typeAttribute);
        knight.Weapons = weapons;

        return knight;
    }
}
