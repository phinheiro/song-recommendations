using Conexia.SR.Domain.PersonalNoteRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conexia.SR.Data.Mappings
{
    public class PersonalNoteMapping : IEntityTypeConfiguration<PersonalNote>
    {
        public void Configure(EntityTypeBuilder<PersonalNote> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired();

            builder.Property(p => p.Body)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.ToTable("PersonalNotes");
        }
    }
}
