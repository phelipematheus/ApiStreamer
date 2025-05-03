using Application.Common;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Login.Commands.Handlers;

public sealed class RecuperaSenhaUsuarioCommandHandler(IUsuarioService usuarioService, ILogger<RecuperaSenhaUsuarioCommandHandler> logger)
    : BaseCommandHandler<RecuperaSenhaUsuarioCommand, string>(logger)
{
    private readonly IUsuarioService _usuarioService = usuarioService;

    protected override async Task<string> ExecuteAsync(RecuperaSenhaUsuarioCommand request, CancellationToken cancellationToken)
    {
        await _usuarioService.RecuperarSenha(request.Email, request.NovaSenha);
        return "Senha Alterada com sucecsso!";
    }
}
