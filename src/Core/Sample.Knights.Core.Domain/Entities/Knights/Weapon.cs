using Sample.Knights.Core.Domain.Enums;

namespace Sample.Knights.Core.Domain.Entities.Knights;

public class Weapon : Identifier
{
    public string Name { get; set; }
    public int Mod { get; set; }
    public TypeAttribute TypeAttribute { get; set; }
    public bool Equipped { get; set; }

    public Weapon() { }    
}
