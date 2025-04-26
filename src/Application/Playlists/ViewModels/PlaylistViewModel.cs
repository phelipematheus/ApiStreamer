using Application.Usuarios.ViewModels;

namespace Application.Playlists.ViewModels;

public record PlaylistViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public UsuarioViewModel Usuario { get; set; } = new();
}

