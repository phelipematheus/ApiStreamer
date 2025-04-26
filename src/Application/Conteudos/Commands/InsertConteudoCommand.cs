using Application.Conteudos.ViewModels;
using Application.Interfaces;

namespace Application.Conteudos.Commands;

public sealed record InsertConteudoCommand(
    string Titulo,
    string Tipo,
    int CriadorId
) : ICommand<ConteudoViewModel>;
