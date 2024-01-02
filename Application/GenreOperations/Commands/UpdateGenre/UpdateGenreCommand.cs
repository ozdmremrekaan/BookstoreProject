using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreViewModel Model { get; set; }
        public int GenreId { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=> x.Id == GenreId);
            if(genre == null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            if (_dbContext.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Aynı isimli kitaptan zaten var.");
            
            genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
            genre.isActive = Model.isActive;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateGenreViewModel
    {
        public string Name {  get; set; }
        public bool isActive { get; set; } = true;
    }
}
