using LearnIt.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnIt.EF.Configurations
{
    public class WordCategory : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).IsRequired();

            builder.HasOne(w => w.Category)
                .WithMany(c => c.Words);
        }
    }
}