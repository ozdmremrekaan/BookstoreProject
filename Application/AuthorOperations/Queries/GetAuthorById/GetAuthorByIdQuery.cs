using AutoMapper;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;


namespace PatikaAkbankBookstore.Application.AuthorOperations.Queries.GetAuthorsById
{
    public class GetAuthorByIdQuery
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDto Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);

            if (author == null)
            {
                // Eğer yazar bulunamazsa, isteğe bağlı olarak hata kontrolü veya başka bir işlem yapabilirsiniz.
                throw new InvalidOperationException("Yazar Bulunamadı");
            }

            // AutoMapper kullanarak Author entity'sini AuthorDto'ya dönüştürme
            var authorDto = _mapper.Map<AuthorDto>(author);

            return authorDto;
        }
    }
}
