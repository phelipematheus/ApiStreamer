using Application.Conteudos.ViewModels;
using Application.ItemPlaylist.Commands;
using Application.ItemPlaylist.Queries;
using Application.ItemPlaylist.ViewModels;
using Application.Playlists.ViewModels;
using CrossCutting;
using CrossCutting.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Web.Endpoints.Base;

namespace Web.Endpoints.Usuarios
{
    [Route("api/")]
    [ApiController]
    public class ItemPlaylistController(IMediator mediator) : ApiControllerBase
    {
        [HttpPost("item-playlists")]
        [SwaggerOperation(
          Summary = "Cria um novo item de playlist.",
          Description = "Esta operação é utilizada para criar um novo item de playlist. Requer as informações obrigatórias no corpo da requisição.",
          OperationId = "post/item-playlists",
          Tags = ["ItemPlaylists"])]
        [ProducesResponseType<InsertItemPlayListViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] InsertItemPlaylistCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Erro na validação dos dados");
            }

            var result = await mediator.Send(command, cancellationToken);
            return Created("", result);
        }

        [HttpDelete("item-playlists/conteudos/{id}")]
        [SwaggerOperation(
            Summary = "Remove um item de playlist.",
            Description = "Esta operação é utilizada para remover um item de playlist no sistema. Requer o ID do item na URL.",
            OperationId = "delete/item-playlist/id",
            Tags = ["ItemPlaylists"])]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] int id, int idPlaylist, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteItemPlaylistCommand(idPlaylist, id), cancellationToken);
            return NoContent();
        }

        [HttpGet("item-playlists/conteudos/{id}")]
        [SwaggerOperation(
            Summary = "Obtém todas as playlists que o conteúdo específico está presente.",
            Description = "Esta operação é utilizada para obter todos as playlists que o conteúdo está presente no sistema. Requer o ID do conteúdo na URL.",
            OperationId = "get/item-playlists/conteudos/id",
            Tags = ["ItemPlaylists"])]
        [ProducesResponseType<IEnumerable<PlaylistViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetByConteudoId([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetItemPlaylistByConteudoIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpGet("item-playlists/playlists/{id}")]
        [SwaggerOperation(
            Summary = "Obtém todos os conteúdos associados a uma playlist.",
            Description = "Esta operação é utilizada para obter todos os itens de playlist no sistema. Requer o ID da playlist na URL.",
            OperationId = "get/item-playlists/playlists/id",
            Tags = ["ItemPlaylists"])]
        [ProducesResponseType<IEnumerable<ConteudoViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetByPlaylistId([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetItemPlaylistByPlaylistIdQuery(id), cancellationToken);
            return Ok(result);
        }
    }
}
