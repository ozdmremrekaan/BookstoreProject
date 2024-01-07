using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestSetup
{
   public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book { Title = "Book1", PageCount = 300, GenreId = 1, PublishDate = new DateTime(1998, 06, 18), AuthorId = 1 },
                    new Book { Title = "Book2", PageCount = 200, GenreId = 2, PublishDate = new DateTime(2001, 06, 18), AuthorId = 2 },
                    new Book { Title = "Book3", PageCount = 250, GenreId = 2, PublishDate = new DateTime(2001, 06, 18), AuthorId = 2 },
                    new Book { Title = "Book4", PageCount = 350, GenreId = 3, PublishDate = new DateTime(2002, 06, 18), AuthorId = 3 },
                    new Book { Title = "Book5", PageCount = 320, GenreId = 1, PublishDate = new DateTime(2005, 06, 18), AuthorId = 1 },
                    new Book { Title = "Book6", PageCount = 123, GenreId = 1, PublishDate = new DateTime(2003, 03, 03), AuthorId = 3 }
                );
        }
    }
}
