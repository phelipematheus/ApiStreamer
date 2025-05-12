using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configuration
{
    internal class ItemPlaylistConfig : IEntityTypeConfiguration<ItemPlaylist>
    {
        public void Configure(EntityTypeBuilder<ItemPlaylist> builder)
        {
            builder.ToTable("ItemPlaylist");

            builder.HasKey(x => new { x.PlaylistId, x.ConteudoId });

            builder.HasOne(x => x.Playlist)
                   .WithMany()
                   .HasForeignKey(x => x.PlaylistId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Conteudo)
                   .WithMany()
                   .HasForeignKey(x => x.ConteudoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
