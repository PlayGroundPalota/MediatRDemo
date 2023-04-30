using System;
namespace SingleSignOnRefactor.Entities
{
    public class SingleSignOnUser
    {
        public string? AzureId { get; set; }
        public string? BpNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

