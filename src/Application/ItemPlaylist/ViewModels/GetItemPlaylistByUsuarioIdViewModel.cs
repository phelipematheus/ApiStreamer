using Application.Conteudos.ViewModels;
using Application.Playlists.ViewModels;

namespace Application.ItemPlaylist.ViewModels
{
    public record GetItemPlaylistByUsuarioIdViewModel
    {
        public PlaylistViewModel Playlist { get; set; } = default!;
        public List<ConteudoViewModel> Conteudos { get; set; } = [];
    }
}
