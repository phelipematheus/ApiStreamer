using Application.Interfaces;
using Application.Usuarios.ViewModels;

namespace Application.Usuarios.Queries;

public sealed record GetUsuarioByEmailQuery(string Email) : IQuery<UsuarioViewModel>;
