using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configuration
{
    internal class CriadorConfig : IEntityTypeConfiguration<Criador>
    {
        public void Configure(EntityTypeBuilder<Criador> builder)
        {
            builder.ToTable("Criador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}