using Application.Playlists.Commands;
using Application.Playlists.Queries;
using Application.Playlists.ViewModels;
using CrossCutting;
using CrossCutting.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web.Endpoints.Base;

namespace Web.Endpoints.Usuarios
{
    [Route("api/")]
    [ApiController]
    public class PlaylistController(IMediator mediator) : ApiControllerBase
    {
        [HttpPost("playlists")]
        [SwaggerOperation(
          Summary = "Cria uma nova playlist.",
          Description = "Esta operação é utilizada para criar uma nova playlist. Requer as informações obrigatórias no corpo da requisição.",
          OperationId = "post/playlist",
          Tags = ["Playlists"])]
        [ProducesResponseType<PlaylistViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] InsertPlaylistCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Erro na validação dos dados");
            }

            var result = await mediator.Send(command, cancellationToken);
            return Created("", result);
        }

        [HttpPut("playlists/{id}")]
        [SwaggerOperation(
        Summary = "Atualiza as informações de uma playlist.",
        Description = "Esta operação é utilizada para atualizar uma playlist existente no sistema. Requer o ID da playlist na URL e as informações atualizadas no corpo da requisição.",
        OperationId = "put/playlist/id",
        Tags = ["Playlists"])]
        [ProducesResponseType<PlaylistViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlaylistCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command with { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("playlists/{id}")]
        [SwaggerOperation(
            Summary = "Remove uma playlist.",
            Description = "Esta operação é utilizada para remover uma playlist no sistema. Requer o ID da playlist na URL.",
            OperationId = "delete/playlist/id",
            Tags = ["Playlists"])]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeletePlaylistCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpGet("playlists/{id}")]
        [SwaggerOperation(
            Summary = "Obtém uma playlist.",
            Description = "Esta operação é utilizada para obter uma playlist no sistema. Requer o ID da playlist na URL.",
            OperationId = "get/playlist/id",
            Tags = ["Playlists"])]
        [ProducesResponseType<PlaylistViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetPlaylistByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpGet("playlists")]
        [SwaggerOperation(
            Summary = "Obtém todas as playlists.",
            Description = "Esta operação é utilizada para obter todas as playlists no sistema.",
            OperationId = "get/playlists",
            Tags = ["Playlists"])]
        [ProducesResponseType<IEnumerable<PlaylistViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllPlaylistsQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
