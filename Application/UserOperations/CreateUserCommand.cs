using AutoMapper;
using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;



namespace PatikaAkbankBookstore.Application.UserOperations
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
            if(user is not null)
            {
                throw new InvalidOperationException("Kullanıcı mevcut.");
            }
            user = _mapper.Map<User>(Model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

            public class CreateUserModel
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public DateTime PublishDate { get; set; }

        }
    }
}
