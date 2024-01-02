using Microsoft.EntityFrameworkCore;
using PatikaAkbankBookstore.Entities;


namespace PatikaAkbankBookstore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Authors.Any() || context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre { Name = "Personal Growth" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Romance" }
                );

                context.Authors.AddRange(
                    new Author { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1975, 05, 12) },
                    new Author { FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1980, 08, 25) },
                    new Author { FirstName = "Alice", LastName = "Smith", BirthDate = new DateTime(1968, 11, 03) }
                );

                context.Books.AddRange(
                    new Book { Title = "Book1", PageCount = 300, GenreId = 1, PublishDate = new DateTime(1998, 06, 18), AuthorId = 1 },
                    new Book { Title = "Book2", PageCount = 200, GenreId = 2, PublishDate = new DateTime(2001, 06, 18), AuthorId = 2 },
                    new Book { Title = "Book3", PageCount = 250, GenreId = 2, PublishDate = new DateTime(2001, 06, 18), AuthorId = 2 },
                    new Book { Title = "Book4", PageCount = 350, GenreId = 3, PublishDate = new DateTime(2002, 06, 18), AuthorId = 3 },
                    new Book { Title = "Book5", PageCount = 320, GenreId = 1, PublishDate = new DateTime(2005, 06, 18), AuthorId = 1 },
                    new Book { Title = "Book6", PageCount = 123, GenreId = 1, PublishDate = new DateTime(2003, 03, 03), AuthorId = 3 }
                );

                context.SaveChanges();
            }
        }
    }
}