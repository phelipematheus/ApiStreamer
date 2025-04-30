namespace Application.Login.Commands;

public sealed record LoginUsuarioCommand(string Email, string Senha) : IRequest<string>;