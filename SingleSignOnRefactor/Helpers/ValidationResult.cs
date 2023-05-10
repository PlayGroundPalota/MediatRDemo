using System;
namespace SingleSignOnRefactor.Helpers
{
    public class ValidationResult : Results, IValidationResult
    {
        public ValidationResult(Err)
        {
        }

        public Error[] Errors => throw new NotImplementedException();
    }
}

