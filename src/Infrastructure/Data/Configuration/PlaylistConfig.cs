using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configuration
{
    internal class PlaylistConfig : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlist");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.HasOne(x => x.Usuario)
                .WithMany(c => c.Playlists)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}