using CrossCutting.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Service.Interfaces;

namespace Service.Conteudo;

public class ConteudoService(IConteudoRepository conteudoRepository, ICriadorRepository criadorRepository) : IConteudoService
{
    private readonly IConteudoRepository _conteudoRepository = conteudoRepository;
    private readonly ICriadorRepository _criadorRepository = criadorRepository;

    public async Task<IConteudo> AdicionarConteudo(string titulo, string tipo, int criadorId)
    {
        var criador = _criadorRepository.GetCriadorById(criadorId) ?? throw new NotFoundException("Criador não encontrado.");
        var conteudo = new Domain.Entities.Conteudo(titulo, tipo, criador.Id)
        {
            Criador = (Domain.Entities.Criador)criador
        };

        _conteudoRepository.AddConteudo(conteudo);
        await _conteudoRepository.SaveChanges();

        return conteudo;
    }

    public async Task<IConteudo> AtualizarConteudo(int conteudoId, string titulo, string tipo)
    {
        var conteudo = _conteudoRepository.GetConteudoById(conteudoId) ?? throw new NotFoundException("Conteúdo não encontrado.");

        conteudo.AtualizarDados(titulo, tipo);

        _conteudoRepository.UpdateConteudo(conteudo);
        await _conteudoRepository.SaveChanges();

        return conteudo;
    }

    public Task<IConteudo> ObterConteudoPorId(int conteudoId)
    {
        var conteudo = _conteudoRepository.GetConteudoById(conteudoId) ?? throw new NotFoundException("Conteúdo não encontrado.");
        return Task.FromResult<IConteudo>(conteudo);
    }

    public Task<IEnumerable<IConteudo>> ObterTodosConteudos()
    {
        var conteudos = _conteudoRepository.GetAllConteudos();
        return Task.FromResult<IEnumerable<IConteudo>>(conteudos);
    }

    public async Task RemoverConteudo(int conteudoId)
    {
        var conteudo = _conteudoRepository.GetConteudoById(conteudoId) ?? throw new NotFoundException("Conteúdo não encontrado.");
        _conteudoRepository.DeleteConteudo(conteudoId);
        await _conteudoRepository.SaveChanges();
    }
}
