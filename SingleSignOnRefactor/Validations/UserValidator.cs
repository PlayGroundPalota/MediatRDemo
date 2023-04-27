using System;
using FluentValidation;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Validations
{
    public class UserValidator : AbstractValidator<SingleSignOnDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
        }
    }
}

