using Application.Interfaces;
using Application.Usuarios.ViewModels;

namespace Application.Usuarios.Queries;

public sealed record GetUsuarioByIdQuery(int Id) : IQuery<UsuarioViewModel>;

