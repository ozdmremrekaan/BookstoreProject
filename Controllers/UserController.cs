using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaAkbankBookstore.Application.CreateToken;
using PatikaAkbankBookstore.Application.UserOperations;
using PatikaAkbankBookstore.DbOperations;
using static PatikaAkbankBookstore.Application.UserOperations.CreateUserCommand;

namespace PatikaAkbankBookstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _DbContext;
        private readonly IMapper _Mapper;
        readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext dbContext,IConfiguration configuration,IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
            _configuration = configuration;

        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_DbContext, _Mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost]
        public IActionResult<Token> CreateToken([FromBody] login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_DbContext, _Mapper);
            command.Model = login;
            command.Handle();

            return token;
        }
    }
}
