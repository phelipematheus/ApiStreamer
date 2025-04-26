using Application.Criadores.ViewModels;
using Application.Interfaces;

namespace Application.Criadores.Queries;

public sealed record GetAllCriadoresQuery() : IQuery<IEnumerable<CriadorViewModel>>;
