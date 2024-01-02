using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PatikaAkbankBookstore.Application.BookOperations.Commands.CreateBook;
using PatikaAkbankBookstore.Application.BookOperations.Commands.DeleteBook;
using PatikaAkbankBookstore.Application.BookOperations.Commands.UpdateBook;
using PatikaAkbankBookstore.Application.BookOperations.Queries.GetBookById;
using PatikaAkbankBookstore.Application.BookOperations.Queries.GetBooks;
using PatikaAkbankBookstore.DbOperations;
using static PatikaAkbankBookstore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static PatikaAkbankBookstore.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace PatikaAkbankBookstore.AddControllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdCommand command = new GetByIdCommand(_context, _mapper);
            command.bookId = id;

            GetBookByIdCommandValidator validator = new GetBookByIdCommandValidator();
            validator.ValidateAndThrow(command);
            var result = command.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.bookId = id;
            command.Model = updatedBook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            command.bookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();


            return Ok();

        }


    }

}