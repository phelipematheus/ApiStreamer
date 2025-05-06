using Application.Conteudos.ViewModels;
using Application.Playlists.ViewModels;

namespace Application.ItemPlaylist.ViewModels;

public record InsertItemPlaylistViewModel
{
    public PlaylistViewModel Playlist { get; set; } = default!;
    public ConteudoViewModel Conteudo { get; set; } = default!;
}
