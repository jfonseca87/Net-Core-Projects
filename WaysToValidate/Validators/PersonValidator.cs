using Domain;
using FluentValidation;

namespace Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Names)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MinimumLength(5).WithMessage("{PropertyName} must be 5 characters minimum")
                .MaximumLength(100).WithMessage("{PropertyName} must be 100 characters maximum");

            RuleFor(x => x.SurNames)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MinimumLength(5).WithMessage("{PropertyName} must be 5 characters minimum")
                .MaximumLength(100).WithMessage("{PropertyName} must be 100 characters maximum");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(100).WithMessage("{PropertyName} must be 100 characters maximum")
                .EmailAddress().WithMessage("{PropertyName} cannot have a valid format");

            RuleFor(x => x.Age)
                .ExclusiveBetween(18, 120).WithMessage("You must be insert a valid {PropertyName} ");
        }
    }
}
