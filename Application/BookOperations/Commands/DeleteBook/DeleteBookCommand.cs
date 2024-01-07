using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int bookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
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
            _dbContext.Books.Remove(book);
        }
    }
}