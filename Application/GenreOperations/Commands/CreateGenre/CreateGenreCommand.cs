using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;

namespace PatikaAkbankBookstore.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {   
        private readonly IBookStoreDbContext _dbContext;
        public CreateGenreModel model { get; set; }

        public CreateGenreCommand(IBookStoreDbContext dbcontext) {

            _dbContext = dbcontext;

        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == model.Name);
            if (genre is not null) {

                throw new InvalidOperationException("Kitap türü zaten Mevcut");
                
            }
            genre = new Genre();
            genre.Name = model.Name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
