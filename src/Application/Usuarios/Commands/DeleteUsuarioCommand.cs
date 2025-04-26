using Application.Global.ViewModels;
using Application.Interfaces;

namespace Application.Usuarios.Commands;

public sealed record DeleteUsuarioCommand(int Id) : ICommand<DeleteViewModel>;