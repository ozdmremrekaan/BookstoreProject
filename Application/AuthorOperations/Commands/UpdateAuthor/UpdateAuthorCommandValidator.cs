using FluentValidation;

namespace PatikaAkbankBookstore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
