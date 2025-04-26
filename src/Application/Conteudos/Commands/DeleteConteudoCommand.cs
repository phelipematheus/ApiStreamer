using Application.Global.ViewModels;
using Application.Interfaces;

namespace Application.Conteudos.Commands;

public sealed record DeleteConteudoCommand(int Id) : ICommand<DeleteViewModel>;
