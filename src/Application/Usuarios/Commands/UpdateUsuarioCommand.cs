using Application.Interfaces;
using Application.Usuarios.ViewModels;

namespace Application.Usuarios.Commands;
public sealed record UpdateUsuarioCommand(int Id, string Nome, string Email, string Senha) : ICommand<UsuarioViewModel>;

