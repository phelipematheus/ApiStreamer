using CrossCutting.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Service.Usuario;

public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public async Task<IUsuario> AdicionarUsuario(string nome, string email)
    {
        var usuario = new Domain.Entities.Usuario(nome, email);

        _usuarioRepository.AddUsuario(usuario);
        await _usuarioRepository.SaveChanges();

        return usuario;
    }

    public async Task<IUsuario> AtualizarUsuario(int id, string nome, string email)
    {
        var usuario = _usuarioRepository.GetUsuarioById(id) ?? throw new NotFoundException("Usuário não encontrado.");

        usuario.AtualizarDados(nome, email);

        _usuarioRepository.UpdateUsuario(usuario);
        await _usuarioRepository.SaveChanges();

        return usuario;
    }

    public async Task RemoverUsuario(int id)
    {
        var usuario = _usuarioRepository.GetUsuarioById(id) ?? throw new NotFoundException("Usuário não encontrado.");

        _usuarioRepository.DeleteUsuario(usuario.Id);
        await _usuarioRepository.SaveChanges();
    }

    public Task<IUsuario> ObterUsuarioPorId(int id)
    {
        var usuario = _usuarioRepository.GetUsuarioById(id) ?? throw new NotFoundException("Usuário não encontrado.");

        return Task.FromResult<IUsuario>(usuario);
    }

    public Task<IEnumerable<IUsuario>> ObterTodosUsuarios()
    {
        var usuarios = _usuarioRepository.GetAllUsuarios();

        return Task.FromResult<IEnumerable<IUsuario>>(usuarios);
    }
}
