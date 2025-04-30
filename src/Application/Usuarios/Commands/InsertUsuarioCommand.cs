using Application.Usuarios.ViewModels;
using Application.Interfaces;

namespace Application.Usuarios.Commands;
public sealed record InsertUsuarioCommand(string Nome, string Email, string Senha) : ICommand<UsuarioViewModel>;

