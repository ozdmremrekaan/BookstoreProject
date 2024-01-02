using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public AuthorDto model { get; set; }
        public int AuthorId;

        public UpdateAuthorCommand(BookStoreDbContext dbContext) {

            _dbContext = dbContext;

        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=> x.Id == AuthorId);

            if(author == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.BirthDate = model.BirthDate;
            _dbContext.SaveChanges();
        }
    }
}
