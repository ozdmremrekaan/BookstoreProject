using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;

namespace PatikaAkbankBookstore.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var books = _dbContext.Books.Include(x=> x.Genre).Include(x => x.Author).OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(books);

            return vm;
        }
    }
    public class BooksViewModel
    {
        public string? Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; set; }
    }

}