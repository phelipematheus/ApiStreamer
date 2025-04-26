using Application.Common;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Queries.Handlers
{
    public sealed class GetAllUsuariosQueryHandler(IUsuarioService usuarioService, ILogger<GetAllUsuariosQueryHandler> logger) :
       BaseQueryHandler<GetAllUsuariosQuery, IEnumerable<UsuarioViewModel>>(logger)
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        protected override async Task<IEnumerable<UsuarioViewModel>> ExecuteAsync(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioService.ObterTodosUsuarios();
            return usuarios.Select(usuario => new UsuarioViewModel{ Id = usuario.Id, Nome = usuario.Nome, Email = usuario.Email });
        }
    }
}
