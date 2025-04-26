using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Domain;
public class PlaylistRepository(StreamerDbContext dbContext) : RepositoryBase(dbContext), IPlaylistRepository
{
    private readonly StreamerDbContext _dbContext = dbContext;

    public IPlaylist GetPlaylistById(int id)
    {
        return _dbContext.Playlists
            .Include(p => p.Usuario)
            .FirstOrDefault(p => p.Id == id)!;
    }
    public IList<IPlaylist> GetAllPlaylists()
    {
        return _dbContext.Playlists
            .Include(p => p.Usuario)
            .Cast<IPlaylist>()
            .ToList();
    }
    public void AddPlaylist(IPlaylist playlist)
    {
        _dbContext.Playlists.Add((Playlist)playlist);
    }
    public void UpdatePlaylist(IPlaylist playlist)
    {
        // Verifica as entradas do ChangeTracker para ver se houve modificações reais na entidade Playlist
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            if (entry.Entity is Playlist && entry.State == EntityState.Modified)
            {
                bool isModified = entry.OriginalValues.Properties
                    .Any(p => !Equals(entry.CurrentValues[p], entry.OriginalValues[p]));

                if (!isModified)
                {
                    entry.State = EntityState.Unchanged;
                }
            }
        }
    }

    public void DeletePlaylist(int id)
    {
        var playlist = _dbContext.Playlists.Find(id);
        if (playlist is not null)
        {
            _dbContext.Playlists.Remove((Playlist)playlist);
        }
    }
}
