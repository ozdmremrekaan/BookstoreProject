using AutoMapper;
using PatikaAkbankBookstore.BookOperations.GetBookById;
using PatikaAkbankBookstore.BookOperations.GetBooks;
using static PatikaAkbankBookstore.BookOperations.CrateBook.CreateBookCommand;

namespace PatikaAkbankBookstore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }
    }
}