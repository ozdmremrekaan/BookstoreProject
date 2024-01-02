using AutoMapper;
using PatikaAkbankBookstore.Application.BookOperations.Queries.GetBookById;
using PatikaAkbankBookstore.Application.BookOperations.Queries.GetBooks;
using PatikaAkbankBookstore.Application.GenreOperations.Queries.GetGenres;
using PatikaAkbankBookstore.Entities;
using static PatikaAkbankBookstore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static PatikaAkbankBookstore.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static PatikaAkbankBookstore.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;


namespace PatikaAkbankBookstore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>(src.Genre.Name).ToString()))
           .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName ?? ""} {src.Author.LastName ?? ""}"));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>(src.Genre.Name).ToString()))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName ?? ""} {src.Author.LastName ?? ""}"));
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorDto>();
        }
    }
}