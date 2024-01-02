using AutoMapper;
using PatikaAkbankBookstore.DbOperations;


namespace PatikaAkbankBookstore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreDetailQuery(IMapper mapper, BookStoreDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.isActive && x.Id == GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı.");
            }

            return _mapper.Map<GenreDetailViewModel>(genre);

        }

        public class GenreDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
