using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaAkbankBookstore.Application.AuthorOperations.Queries.GetAuthors;
using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Application.AuthorOperations.Queries.GetAuthorsById;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.Application.AuthorOperations.Commands.CreateAuthor;
using FluentValidation;
using PatikaAkbankBookstore.Application.AuthorOperations.Commands.UpdateAuthor;
using PatikaAkbankBookstore.Application.AuthorOperations.Commands.DeleteAuthor;

namespace PatikaAkbankBookstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
            
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_dbContext, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_dbContext, _mapper);
            query.AuthorId = id;
            var result = query.Handle();
            
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorDto newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext);
            command.model = newAuthor;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id,[FromBody] AuthorDto updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            command.AuthorId = id;
            command.model = updatedAuthor;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {   
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            command.AuthorId = id;
            
            command.Handle();
            return Ok();
        }
    }
}
