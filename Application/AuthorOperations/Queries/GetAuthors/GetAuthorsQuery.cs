using AutoMapper;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorDto> Handle()
        {
            var authors = _dbContext.Authors.ToList();
            return _mapper.Map<List<AuthorDto>>(authors);
        }
    }
}
