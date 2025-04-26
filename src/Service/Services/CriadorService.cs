using CrossCutting.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Criador;

public class CriadorService(ICriadorRepository criadorRepository) : ICriadorService
{
    private readonly ICriadorRepository _criadorRepository = criadorRepository;

    public async Task<ICriador> AdicionarCriador(string nome)
    {
        var criador = new Domain.Entities.Criador(nome);

        _criadorRepository.AddCriador(criador);
        await _criadorRepository.SaveChanges();

        return criador;
    }

    public async Task<ICriador> AtualizarCriador(int criadorId, string nome)
    {
        var criador = _criadorRepository.GetCriadorById(criadorId) ?? throw new NotFoundException("Criador não encontrado.");

        criador.AtualizarDados(nome);

        _criadorRepository.UpdateCriador(criador);
        await _criadorRepository.SaveChanges();

        return criador;
    }
    public Task<ICriador> ObterCriadorPorId(int criadorId)
    {
        var criador = _criadorRepository.GetCriadorById(criadorId) ?? throw new NotFoundException("Criador não encontrado.");
        return Task.FromResult<ICriador>(criador);
    }
    public Task<IEnumerable<ICriador>> ObterTodosCriadores()
    {
        var criadores = _criadorRepository.GetAllCriadores();
        return Task.FromResult<IEnumerable<ICriador>>(criadores);
    }
    public async Task RemoverCriador(int criadorId)
    {
        var criador = _criadorRepository.GetCriadorById(criadorId) ?? throw new NotFoundException("Criador não encontrado.");
        _criadorRepository.DeleteCriador(criador.Id);
        await _criadorRepository.SaveChanges();
    }
}
