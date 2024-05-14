using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using Sample.Knights.Core.Application.DataTransferObjects.HttpResponse;
using Sample.Knights.Core.Application.DataTransferObjects.Knights;
using Sample.Knights.Core.Application.Interfaces;

namespace Sample.Knights.UI.Api.Controllers;

[ApiController]
[Route("knights")]
[Produces("application/json")]
public class KnightController(IKnightApplicationService knightApplicationService) : BaseController, IDisposable
{
    /// <summary>
    /// Lista todos os cavaleiros por filtro
    /// </summary>
    /// <param name="filter">Informe ou não o texto 'heroes', caso informado será listado todos os cavaleiras que se tornaram heróis </param>
    /// <returns>Lista de cavaleiros <see cref="KnightResume"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<KnightResume>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(ExceptionResult))]
    public async Task<object> GetKnights([FromQuery] string filter)
    {
        var result = await knightApplicationService.Get(filter);
        return ResponseResult(result);
    }

    /// <summary>
    /// Lista um cavaleiro por id
    /// </summary>
    /// <param name="id">código do cavaleiro <see cref="ObjectId"></param>
    /// <returns>Detalhes do cavalheiro <see cref="KnightDetail"/></returns>
    [HttpGet, Route("{id}") ]
    [ProducesResponseType(typeof(KnightDetail), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(ExceptionResult))]
    public async Task<object> GetKnightById([FromRoute] string id)
    {
        var result = await knightApplicationService.GetById(id);
        return ResponseResult(result);
    }

    /// <summary>
    /// Remove um cavaleiro por id, transformando-o em herói
    /// </summary>
    /// <param name="id">código do cavaleiro <see cref="ObjectId"></param>
    /// <returns>Status da operação</returns>
    [HttpDelete, Route("{id}") ]
    [ProducesResponseType(typeof(StatusCodes), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(ExceptionResult))]
    public async Task<object> RemoveKnightById([FromRoute] string id)
    {
        await knightApplicationService.RemoveById(id);
        return ResponseResult();
    }

    /// <summary>
    /// Insere um novo cavaleiro
    /// </summary>
    /// <param name="model">Dados do cavaleiro <see cref="KnightInsert"</param>
    /// <returns>Detalhes do cavalheiro <see cref="KnightDetail"/></returns>
    [HttpPost]
    [ProducesResponseType(typeof(KnightDetail), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(ExceptionResult))]
    public async Task<object> InsertKnight([FromBody] KnightInsert model)
    {
        var result = await knightApplicationService.Insert(model);
        return ResponseResult(result);
    }

    /// <summary>
    /// Atualiza um cavaleiro, alterando seu apelido 
    /// </summary>
    /// <param name="id">código do cavaleiro <see cref="ObjectId"></param>
    /// <param name="model">Dados do cavaleiro <see cref="KnightUpdate"</param>
    /// <returns>Detalhes do cavalheiro <see cref="KnightDetail"/></returns>
    [HttpPatch, Route("{id}") ]
    [ProducesResponseType(typeof(KnightDetail), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
    [ProducesErrorResponseType(typeof(ExceptionResult))]
    public async Task<object> UpdateKnight([FromRoute] string id, [FromBody] KnightUpdate model)
    {
        var result = await knightApplicationService.Update(id, model);
        return ResponseResult(result);
    }

    [NonAction]
    public void Dispose()
    {
        knightApplicationService?.Dispose();

        GC.SuppressFinalize(this);
    }
}
