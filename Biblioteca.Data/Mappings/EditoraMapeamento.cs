using Biblioteca.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Mappings
{
    public class EditoraMapeamento : IEntityTypeConfiguration<EditoraModel>
    {
        public void Configure(EntityTypeBuilder<EditoraModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Documento).IsRequired().HasColumnType("varchar(14)");
        }
    }
}
