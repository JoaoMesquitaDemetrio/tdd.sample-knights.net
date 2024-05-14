using Sample.Knights.Core.Application.DataTransferObjects.Knights;

namespace Sample.Knights.Core.Application.Interfaces;

public interface IKnightApplicationService : IDisposable
{
    public Task<IEnumerable<KnightResume>> Get(string filter);
    public Task<KnightDetail> GetById(string id);
    public Task RemoveById(string id);
    public Task<KnightDetail> Insert(KnightInsert model);
    public Task<KnightDetail> Update(string id, KnightUpdate model);
}
