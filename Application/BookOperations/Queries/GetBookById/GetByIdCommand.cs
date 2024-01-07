using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.BookOperations.Queries.GetBookById
{
    public class GetByIdCommand
    {

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int bookId { get; set; }

        public GetByIdCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=> x.Genre).Include(x=> x.Author).SingleOrDefault(x => x.Id == bookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap mevcut değil");
            }
            var model = _mapper.Map<BookViewModel>(book);
            return model;


        }
    }
    public class BookViewModel
    {
        public string? Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; internal set; }
    }

}