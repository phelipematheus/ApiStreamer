using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories;
public interface IPlaylistRepository : IRepository
{
    IPlaylist GetPlaylistById(int id);
    IList<IPlaylist> GetAllPlaylists();
    IList<IPlaylist> GetPlaylistsByUsuarioId(int usuarioId);
    void AddPlaylist(IPlaylist playlist);
    void UpdatePlaylist(IPlaylist playlist);
    void DeletePlaylist(int id);
}
