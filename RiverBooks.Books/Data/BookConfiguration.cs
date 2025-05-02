using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books.Data
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        internal static readonly Guid BookGuid1 = Guid.NewGuid();
        internal static readonly Guid BookGuid2 = Guid.NewGuid();
        internal static readonly Guid BookGuid3 = Guid.NewGuid();

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .Property(p => p.Title)
                .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGHT)
                .IsRequired();

            builder
                .Property(p => p.Author)
                .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGHT)
                .IsRequired();

            builder.HasData(GetSampleBookData());
        }

        private IEnumerable<Book> GetSampleBookData()
        {
            var tolkien = "J.R.R. Tolkien";
            yield return new Book(BookGuid1, "The Hobbit", tolkien, 10.99m);
            yield return new Book(BookGuid2, "The Lord of the Rings", tolkien, 29.99m);
            yield return new Book(BookGuid3, "The Silmarillion", tolkien, 19.99m);
        }
    }
}
