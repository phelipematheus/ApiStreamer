using Application.Interfaces;

namespace Application.Login.Commands;

public sealed record RecuperaSenhaUsuarioCommand(string Email, string NovaSenha) : ICommand<string>;

