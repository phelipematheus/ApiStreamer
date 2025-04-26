using Application.Criadores.Commands;
using Application.Criadores.Queries;
using Application.Criadores.ViewModels;
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
    public class CriadorController(IMediator mediator) : ApiControllerBase
    {
        [HttpPost("criadores")]
        [SwaggerOperation(
          Summary = "Cria um novo registro de criador",
          Description = "Esta operação é utilizada para criar um novo registro de criador. Requer as informações obrigatórias no corpo da requisição.",
          OperationId = "post/criador",
          Tags = ["Criadores"])]
        [ProducesResponseType<CriadorViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] InsertCriadorCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Erro na validação dos dados");
            }

            var result = await mediator.Send(command, cancellationToken);
            return Created("", result);
        }

        [HttpPut("criadores/{id}")]
        [SwaggerOperation(
        Summary = "Atualiza as informações do criador.",
        Description = "Esta operação é utilizada para atualizar um registro de criador existente no sistema. Requer o ID do criador na URL e as informações atualizadas no corpo da requisição.",
        OperationId = "put/criador/id",
        Tags = ["Criadores"])]
        [ProducesResponseType<CriadorViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCriadorCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command with { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("criadores/{id}")]
        [SwaggerOperation(
            Summary = "Remove um registro de criador.",
            Description = "Esta operação é utilizada para remover um registro de criador no sistema. Requer o ID do criador na URL.",
            OperationId = "delete/criador/id",
            Tags = ["Criadores"])]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteCriadorCommand(id), cancellationToken);
            return NoContent();
        }

        [HttpGet("criadores/{id}")]
        [SwaggerOperation(
            Summary = "Obtém um registro de criador.",
            Description = "Esta operação é utilizada para obter um registro de criador no sistema. Requer o ID do criador na URL.",
            OperationId = "get/criador/id",
            Tags = ["Criadores"])]
        [ProducesResponseType<CriadorViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetCriadorByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpGet("criadores")]
        [SwaggerOperation(
            Summary = "Obtém todos os registros de criadores.",
            Description = "Esta operação é utilizada para obter todos os registros de criadores no sistema.",
            OperationId = "get/criadores",
            Tags = ["Criadores"])]
        [ProducesResponseType<IEnumerable<CriadorViewModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllCriadoresQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
