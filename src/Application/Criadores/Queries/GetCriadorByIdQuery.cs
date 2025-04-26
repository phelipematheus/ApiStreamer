using Application.Criadores.ViewModels;
using Application.Interfaces;

namespace Application.Criadores.Queries;

public sealed record GetCriadorByIdQuery(int Id) : IQuery<CriadorViewModel>;
