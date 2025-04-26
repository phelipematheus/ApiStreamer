using Application.Conteudos.ViewModels;
using Application.Interfaces;

namespace Application.Conteudos.Commands;

public sealed record UpdateConteudoCommand(int Id, string Titulo, string Tipo) : ICommand<ConteudoViewModel>;
