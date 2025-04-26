using Application.Common;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Usuarios.Queries.Handlers
{
    public class GetUsuarioByIdQueryHandler(IUsuarioService usuarioService, ILogger<GetUsuarioByIdQueryHandler> logger) :
       BaseQueryHandler<GetUsuarioByIdQuery, UsuarioViewModel>(logger)
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        protected override async Task<UsuarioViewModel> ExecuteAsync(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(request.Id);
            return new UsuarioViewModel{ Id = usuario.Id, Nome = usuario.Nome, Email = usuario.Email };
        }
    }
}
