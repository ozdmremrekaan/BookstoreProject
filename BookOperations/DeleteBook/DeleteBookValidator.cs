using FluentValidation;

namespace PatikaAkbankBookstore.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
          
        }

    }
}