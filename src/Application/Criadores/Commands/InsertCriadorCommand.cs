using Application.Criadores.ViewModels;
using Application.Interfaces;

namespace Application.Criadores.Commands;

public sealed record InsertCriadorCommand(string Nome) : ICommand<CriadorViewModel>;
