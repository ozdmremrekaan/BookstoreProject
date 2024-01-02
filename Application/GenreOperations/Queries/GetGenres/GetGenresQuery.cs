using AutoMapper;
using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.isActive).OrderBy(x => x.Id);
            List<GenreViewModel> obj = _mapper.Map<List<GenreViewModel>>(genres);
            return obj;
        }

        public class GenreViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
