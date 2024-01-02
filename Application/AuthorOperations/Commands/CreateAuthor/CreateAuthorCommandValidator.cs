using FluentValidation;

namespace PatikaAkbankBookstore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator: AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
