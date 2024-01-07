using AutoMapper;
using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;
using UnitTest.TestSetup;
using PatikaAkbankBookstore.Application.BookOperations.Commands.CreateBook;
using static PatikaAkbankBookstore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using FluentAssertions;

namespace UnitTest.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookTest: IClassFixture<CommonTextFixture>
    {
       private readonly BookStoreDbContext _context;
        private readonly IMapper _mappper;

        public CreateBookTest(CommonTextFixture testFixture)
        {
            _context = testFixture.Context;
            _mappper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExitBookTitleIsGivenException_ShouldBeReturn()
        {
            //arrange (Hazırlık)
            var book = new Book() { Title = "Test_WhenAlreadyExitBookTitleIsGivenException_ShouldBeReturn", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mappper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act (çalıştırma) & Assert (Doğrulama)
            FluentActions
               .Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap mevcut");
        }

        [Fact]
        public void WhenValidInputsAreaGiven_Book_shouldBeCreated()
        {
            //Arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mappper);
            CreateBookModel model = new CreateBookModel() { Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1 };
            command.Model = model;

            //Act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title );
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
        }

    }
}
