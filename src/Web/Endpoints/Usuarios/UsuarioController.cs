using CrossCutting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web.Endpoints.Base;
using CrossCutting.Exceptions;
using Application.Usuarios.ViewModels;
using Application.Usuarios.Commands;
using Application.Usuarios.Queries;
using Application.Login.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Web.Endpoints.Usuarios;

[Route("api/")]
[ApiController]
public class UsuarioController(IMediator mediator) : ApiControllerBase
{
    [HttpPost("usuarios")]
    [SwaggerOperation(
      Summary = "Cria um novo registro de usuário para uma playlist",
      Description = "Esta operação é utilizada para criar um novo registro de usuário para uma playlist. Requer as informações obrigatórias no corpo da requisição.",
      OperationId = "post/usuario",
      Tags = ["Usuarios"])]
    [ProducesResponseType<UsuarioViewModel>(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] InsertUsuarioCommand command, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException("Erro na validação dos dados");
        }

        var result = await mediator.Send(command, cancellationToken);
        return Created("", result);
    }

    [Authorize]
    [HttpPut("usuarios/{id}")]
    [SwaggerOperation(
    Summary = "Atualiza as informações do usuário da Playlist.",
    Description = "Esta operação é utilizada para atualizar um registro de usuário de uma determinada playlist existente no sistema. Requer o ID do usuario na URL e as informações atualizadas no corpo da requisição.",
    OperationId = "put/usuario/id",
    Tags = ["Usuarios"])]
    [ProducesResponseType<UsuarioViewModel>(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsuarioCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command with { Id = id }, cancellationToken);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete("usuarios/{id}")]
    [SwaggerOperation(
        Summary = "Remove um registro de usuário.",
        Description = "Esta operação é utilizada para remover um registro de usuário no sistema. Requer o ID do usuário na URL.",
        OperationId = "delete/usuario/id",
        Tags = ["Usuarios"])]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]

    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUsuarioCommand(id), cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpGet("usuarios/{id}")]
    [SwaggerOperation(
        Summary = "Obtém um registro de usuário.",
        Description = "Esta operação é utilizada para obter um registro de usuário no sistema. Requer o ID do usuário na URL.",
        OperationId = "get/usuario/id",
        Tags = ["Usuarios"])]
    [ProducesResponseType<UsuarioViewModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUsuarioByIdQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet("usuarios/email")]
    [SwaggerOperation(
        Summary = "Obtém um registro de usuário por email.",
        Description = "Esta operação é utilizada para obter um registro de usuário no sistema. Requer o email do usuário.",
        OperationId = "get/usuario/email",
        Tags = ["Usuarios"])]
    [ProducesResponseType<UsuarioViewModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Get(string email, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUsuarioByEmailQuery(email), cancellationToken);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("usuarios")]
    [SwaggerOperation(
        Summary = "Obtém todos os registros de usuários.",
        Description = "Esta operação é utilizada para obter todos os registros de usuários no sistema.",
        OperationId = "get/usuarios",
        Tags = ["Usuarios"])]
    [ProducesResponseType<IEnumerable<UsuarioViewModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllUsuariosQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [SwaggerOperation(
    Summary = "Autentica um usuário",
    Description = "Retorna um token JWT se as credenciais forem válidas",
    OperationId = "post/login",
    Tags = ["Login"])]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command, CancellationToken cancellationToken)
    {
        var token = await mediator.Send(command, cancellationToken);
        return Ok(new { Token = token });
    }

    [HttpPost("login/recuperar-senha")]
    [AllowAnonymous]
    [SwaggerOperation(
    Summary = "Recupera senha de um usuário",
    Description = "Busca o usuário pelo email, caso o mesmo exista a senha é alterada",
    OperationId = "post/login/recuperar-senha",
    Tags = ["Login"])]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetail), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RecuperaSenha([FromBody] RecuperaSenhaUsuarioCommand command, CancellationToken cancellationToken)
    {
        var token = await mediator.Send(command, cancellationToken);
        return Ok();
    }
}
