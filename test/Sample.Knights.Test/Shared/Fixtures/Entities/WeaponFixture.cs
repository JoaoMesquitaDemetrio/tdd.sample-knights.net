using Sample.Knights.Core.Domain.Entities.Knights;
using Sample.Knights.Core.Domain.Enums;
using Sample.Knights.Test.Shared.Utils;


namespace Sample.Knights.Test.Shared.Fixtures.Entities;

public sealed class WeaponFixture
{
    public WeaponFixture() { }

    public static Weapon CreateWeapon()
    {
        return new Weapon
        {
            Id = Guid.NewGuid().ToString(),
            Name = Extensions.RandomString(500),
            Mod = Extensions.RandomIntegerBetween(-2, 3)
        };
    }

    public static Weapon CreateWeapon(TypeAttribute typeAttribute)
    {
        var weapon = CreateWeapon();
        weapon.TypeAttribute = typeAttribute;

        return weapon;
    }

    public static Weapon CreateWeapon(TypeAttribute typeAttribute, bool equipped)
    {
        var weapon = CreateWeapon(typeAttribute);
        weapon.Equipped = equipped;

        return weapon;
    }
}
