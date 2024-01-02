using FluentValidation;

namespace PatikaAkbankBookstore.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}
