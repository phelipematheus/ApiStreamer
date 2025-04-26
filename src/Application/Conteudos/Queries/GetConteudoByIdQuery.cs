using Application.Conteudos.ViewModels;
using Application.Interfaces;

namespace Application.Conteudos.Queries;

public sealed record GetConteudoByIdQuery(int Id) : IQuery<ConteudoViewModel>;
