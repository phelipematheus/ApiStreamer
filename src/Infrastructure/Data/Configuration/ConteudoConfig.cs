using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configuration
{
    internal class ConteudoConfig : IEntityTypeConfiguration<Conteudo>
    {
        public void Configure(EntityTypeBuilder<Conteudo> builder)
        {
            builder.ToTable("Conteudo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CriadorId).IsRequired();
            builder.HasOne(x => x.Criador)
                .WithMany(c => c.Conteudos)
                .HasForeignKey(x => x.CriadorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
