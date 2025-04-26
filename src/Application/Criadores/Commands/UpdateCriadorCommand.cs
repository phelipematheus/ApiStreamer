using Application.Criadores.ViewModels;
using Application.Interfaces;

namespace Application.Criadores.Commands;

public sealed record UpdateCriadorCommand(int Id, string Nome) : ICommand<CriadorViewModel>;
