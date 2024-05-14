using Sample.Knights.Core.Application.DataTransferObjects.Knights;
using Sample.Knights.Core.Application.Interfaces;
using Sample.Knights.Core.Domain.Filters;
using Sample.Knights.Core.Domain.Interfaces;
using Sample.Knights.Core.Domain.Interfaces.Repositories;
using Sample.Utils.Extensions;
using Sample.Knights.Core.Domain.Entities.Knights;

namespace Sample.Knights.Core.Application.Services;

public class KnightApplicationService(
    IMongoDBContext context, 
    IKnightService knightService) : IKnightApplicationService
{
    public async Task<IEnumerable<KnightResume>> Get(string filter)
    {
        var filters = new KnightFilters(filter);
        var entities = await knightService.GetWithFilters(filters);

        return entities?.Select(x => new KnightResume(x)) ?? new List<KnightResume>();
    }

    public async Task<KnightDetail> GetById(string id)
    {
        var entity = await knightService.GetById(id) ?? new Knight();
        return new KnightDetail(entity);
    }

    public async Task<KnightDetail> Insert(KnightInsert model)
    {
        if (model.IsNull())
            throw new ArgumentException("Cavalheiro inválido");

        var entity = model.TransferTo(); 
        await knightService.Insert(entity);
        
        return await GetById(entity.Id);
    }

    public async Task RemoveById(string id)
    {
        var entity = await knightService.GetById(id);
        if (entity.IsNull())
            throw new ArgumentException("Cavalheiro não encontrado");

        entity.Remove();
        await knightService.Update(entity);
    }

    public async Task<KnightDetail> Update(string id, KnightUpdate model)
    {
        if (model.IsNull())
            throw new ArgumentException("Cavalheiro inválido");

        var entity = await knightService.GetById(id);
        if (entity.IsNull())
            throw new ArgumentException("Cavalheiro não encontrado");

        model.UpdateEntity(entity);
        await knightService.Update(entity);

        return await GetById(entity.Id);
    }

    public void Dispose()
    {
        context?.Dispose();
        knightService?.Dispose();

        GC.SuppressFinalize(this);
    }
}
