using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Sample.Knights.Core.Application.DataTransferObjects.Knights;

namespace Sample.Knights.Core.Application.Interfaces;

public interface IKnightApplicationService : IDisposable
{
    public Task<IEnumerable<KnightResume>> Get(string filter);
    public Task<KnightDetail> GetById(Guid id);
    public Task RemoveById(Guid id);
    public Task<KnightDetail> Insert(KnightInsert model);
    public Task<KnightDetail> Update(Guid id, KnightUpdate model);
}
