using Application.Common;
using Application.Global.ViewModels;
using Application.Usuarios.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Commands.Handlers
{
    public sealed class DeleteUsuarioCommandHandler(IUsuarioService usuarioService, ILogger<DeleteUsuarioCommandHandler> logger) :
       BaseCommandHandler<DeleteUsuarioCommand, DeleteViewModel>(logger)
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        protected override async Task<DeleteViewModel> ExecuteAsync(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            await _usuarioService.RemoverUsuario(request.Id);
            return new DeleteViewModel(request.Id, "Usuário removido com sucesso.");
        }
    }
}
