using Sample.Knights.Core.Domain.Constants;
using Sample.Knights.Core.Domain.Enums;
using Sample.Utils.Extensions;

namespace Sample.Knights.Core.Domain.Entities.Knight;

public class Knight : BaseEntity
{
    public string Name { get; set; }
    public string Nickname { get; set; }
    public DateTime Birthday { get; set; }
    public Attributes Attributes { get; set; }
    public IEnumerable<Weapon> Weapons { get; set; }
    public TypeAttribute KeyAttribute { get; set; }  

    public Knight() 
        => Attributes = new Attributes();
    
    public void UpdateNickname(string nickname)
        => Nickname = nickname;

    public bool HasWeaponEquipped()
        => Weapons?.Any(w => w.Equipped) ?? false;

    public Weapon GetWeaponEquipped()
        => Weapons?.FirstOrDefault(w => w.Equipped);

    public int GetModFromEquippedWeapon()
        => GetWeaponEquipped()?.Mod ?? 0;

    public int GetModFromCurrentAttribute() 
        => Attributes?.GetModFromAttribute(KeyAttribute) ?? 0;
        
    public int GetAge()
        => Birthday.IsNullDateTime() ? 0 : Birthday.Date.CalculateAge();

    public int GetAttack()
        => AppConstants.DEFAULT_ATTACK + GetModFromCurrentAttribute() + GetModFromEquippedWeapon();

    public bool HasMinimumAge()
        => GetAge() >= AppConstants.MINIMAL_AGE;

    public double GetExperience() 
    {
        if (HasMinimumAge() == false)
            return 0;

        return Math.Floor((GetAge() - AppConstants.MINIMAL_AGE) * Math.Pow(AppConstants.EXPERIENCE_POW_X, AppConstants.EXPERIENCE_POW_Y));
    }
}
