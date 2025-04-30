using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Login.Commands.Handlers;
public sealed class LoginUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IConfiguration config)
    : IRequestHandler<LoginUsuarioCommand, string>
{
    public Task<string> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = usuarioRepository.GetAllUsuarios()
            .FirstOrDefault(u => u.Email == request.Email && u.Senha == request.Senha);

        if (usuario is null)
            throw new UnauthorizedAccessException("Credenciais inválidas");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(config["Jwt:Secret"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}