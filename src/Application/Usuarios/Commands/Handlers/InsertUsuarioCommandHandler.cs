using Application.Common;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Usuarios.Commands.Handlers;
public sealed class InsertUsuarioCommandHandler(IUsuarioService usuarioService, ILogger<InsertUsuarioCommandHandler> logger) :
       BaseCommandHandler<InsertUsuarioCommand, UsuarioViewModel>(logger)
{
    private readonly IUsuarioService _usuarioService = usuarioService;
    protected override async Task<UsuarioViewModel> ExecuteAsync(InsertUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioService.AdicionarUsuario(request.Nome, request.Email, request.Senha);
        return new UsuarioViewModel{
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }
}
