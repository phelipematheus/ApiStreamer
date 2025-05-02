using Application.Common;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Usuarios.Queries.Handlers
{
    public class GetUsuarioByEmailQueryHandler(IUsuarioService usuarioService, ILogger<GetUsuarioByEmailQueryHandler> logger) :
        BaseQueryHandler<GetUsuarioByEmailQuery, UsuarioViewModel>(logger)
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        protected override async Task<UsuarioViewModel> ExecuteAsync(GetUsuarioByEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioService.ObterUsuarioPorEmail(request.Email);
            return new UsuarioViewModel { Id = usuario.Id, Nome = usuario.Nome, Email = usuario.Email };
        }
    }
}
