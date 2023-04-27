using System;
using FluentValidation;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Validations
{
    public class UserValidator : AbstractValidator<SingleSignOnDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Name property is required")
             .Length(2, 50).WithMessage("Name must be between 2 to 50 characters");

            RuleFor(user => user.LastName).NotEmpty().WithMessage("LastName property is required")
                .Length(2, 50).WithMessage("LastName must be between 2 to 50 characters");
        }
    }
}

