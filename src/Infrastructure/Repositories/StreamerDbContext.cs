using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class StreamerDbContext(DbContextOptions<StreamerDbContext> options) : DbContext(options)
{
    public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => builder.AddConsole());

    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Conteudo> Conteudos { get; set; }
    public DbSet<Criador> Criadores { get; set; }
    public DbSet<ItemPlaylist> PlaylistConteudos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);    
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StreamerDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        base.OnConfiguring(optionsBuilder);
    }
}
