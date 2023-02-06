using AgendaBlue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaBlue.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {

        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.phone).IsRequired().HasMaxLength(11);


        }
    }
}
