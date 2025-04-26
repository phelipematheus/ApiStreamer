using Application.Conteudos.Commands;
using Application.Conteudos.Queries;
using Application.Conteudos.ViewModels;
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
    public class ConteudoController(IMediator mediator) : ApiControllerBase
    {
        [HttpPost("conteudos")]
        [SwaggerOperation(
          Summary = "Cria um novo registro de conteúdo",
          Description = "Esta operação é utilizada para criar um novo registro de conteúdo. Requer as informações obrigatórias no corpo da requisição.",
          OperationId = "post/conteudo",
          Tags = ["Conteudos"])]
        [ProducesResponseType<ConteudoViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] InsertConteudoCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Erro na validação dos dados");
            }

            var result = await mediator.Send(command, cancellationToken);
            return Created("", result);
        }

        [HttpPut("conteudos/{id}")]
        [SwaggerOperation(
        Summary = "Atualiza as informações do conteúdo.",
        Description = "Esta operação é utilizada para atualizar um registro de conteúdo existente no sistema. Requer o ID do conteúdo na URL e as informações atualizadas no corpo da requisição.",
        OperationId = "put/conteudo/id",
        Tags = ["Conteudos"])]
        [ProducesResponseType<ConteudoViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateConteudoCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command with { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("conteudos/{id}")]
        [SwaggerOperation(
            Summary = "Remove um registro de conteúdo.",
            Description = "Esta operação é utilizada para remover um registro de conteúdo no sistema. Requer o ID do conteúdo na URL.",
            OperationId = "delete/conteudo/id",
            Tags = ["Conteudos"])]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteConteudoCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpGet("conteudos/{id}")]
        [SwaggerOperation(
            Summary = "Obtém um registro de conteúdo.",
            Description = "Esta operação é utilizada para obter um registro de conteúdo no sistema. Requer o ID do conteúdo na URL.",
            OperationId = "get/conteudo/id",
            Tags = ["Conteudos"])]
        [ProducesResponseType<ConteudoViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetConteudoByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpGet("conteudos")]
        [SwaggerOperation(
            Summary = "Obtém todos os registros de conteúdos.",
            Description = "Esta operação é utilizada para obter todos os registros de conteúdos no sistema.",
            OperationId = "get/conteudos",
            Tags = ["Conteudos"])]
        [ProducesResponseType<IEnumerable<ConteudoViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllConteudosQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
