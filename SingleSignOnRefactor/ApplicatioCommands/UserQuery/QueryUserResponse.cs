using System;
namespace SingleSignOnRefactor.ApplicatioCommands.UserQuery
{
    public class QueryUserResponse
    {
        public int Id { get; set; }
        public string? AzureId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

