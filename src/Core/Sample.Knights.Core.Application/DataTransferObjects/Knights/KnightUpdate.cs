using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.DataTransferObjects.Knights;

public record KnightUpdate(string Nickname) : Identifier<Knight>(Guid.Empty)
{
    public override Knight TransferTo()
        => new Knight { Nickname = Nickname };

    public override void UpdateEntity(Knight entity)
        => entity.UpdateNickname(Nickname);
}
