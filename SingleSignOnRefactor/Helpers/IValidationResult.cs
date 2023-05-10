using System;
namespace SingleSignOnRefactor.Helpers
{
    public interface IValidationResult
    {
        static readonly Error ValidationError = new Error("ValidationError", "A validation problem occured");
        Error[] Errors { get; }
    }
}

