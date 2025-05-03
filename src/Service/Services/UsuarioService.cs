using CrossCutting.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Service.Usuario;

public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public async Task<IUsuario> AdicionarUsuario(string nome, string email, string senha)
    {
        var usuario = new Domain.Entities.Usuario(nome, email, senha);

        _usuarioRepository.AddUsuario(usuario);
        await _usuarioRepository.SaveChanges();

        return usuario;
    }

    public async Task<IUsuario> AtualizarUsuario(int id, string nome, string email, string senha)
    {
        var usuario = _usuarioRepository.GetUsuarioById(id) ?? throw new NotFoundException("Usuário não encontrado.");

        usuario.AtualizarDados(nome, email, senha);

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

    public Task<IUsuario> ObterUsuarioPorEmail(string email)
    {
        var usuario = _usuarioRepository.GetUsuarioByEmail(email) ?? throw new NotFoundException("Não foi encontrado nenhum usuário com o email informado.");

        return Task.FromResult<IUsuario>(usuario);
    }

    public Task<IEnumerable<IUsuario>> ObterTodosUsuarios()
    {
        var usuarios = _usuarioRepository.GetAllUsuarios();

        return Task.FromResult<IEnumerable<IUsuario>>(usuarios);
    }

    public async Task RecuperarSenha(string email, string novaSenha)
    {
        var usuario = _usuarioRepository.GetUsuarioByEmail(email)
                      ?? throw new NotFoundException("Usuário não encontrado com o e-mail informado.");

        usuario.AtualizarSenha(novaSenha);

        _usuarioRepository.UpdateUsuario(usuario);
        await _usuarioRepository.SaveChanges();
    }

}
