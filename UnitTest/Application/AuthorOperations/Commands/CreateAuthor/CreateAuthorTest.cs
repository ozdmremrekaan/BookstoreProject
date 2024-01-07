using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.Application.AuthorOperations.Commands.CreateAuthor;
using PatikaAkbankBookstore.DbOperations;
using UnitTest.TestSetup;
using PatikaAkbankBookstore.Entities;
using FluentAssertions;
using static PatikaAkbankBookstore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;


namespace UnitTest.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorTest : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _dbContext;


        public CreateAuthorTest(CommonTextFixture textFixture)
        {
            _dbContext = textFixture.Context;

        }
        [Fact]
        public void WhenAuthorIsFound_InvalidOperationException_ShouldReturnError()
        {
            // arrange

            var author = new Author() { FirstName = "John", LastName = "Doe" };
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext);
            command.model = new AuthorDto() { FirstName = author.FirstName, LastName = author.LastName };

            //act && assert
            FluentActions
                .Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Bu yazar zaten mevcut");

        }
        [Fact]
        public void WhenAuthorCreation_IsAccepted_ShouldReturnNoError()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext);
            AuthorDto model = new AuthorDto() { FirstName = "Merve", LastName = "Çolak", BirthDate = new DateTime(1986,04,14) };
            command.model = model;
        }
    }
}
