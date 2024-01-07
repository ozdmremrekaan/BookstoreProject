using Microsoft.AspNetCore.Mvc;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public int bookId { get; set; }
        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == bookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap mevcut değil");
            }
            book.Title = Model.Title;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;
            _dbContext.SaveChanges();


        }
        public class UpdateBookModel
        {
            public string? Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }

        }

    }

}