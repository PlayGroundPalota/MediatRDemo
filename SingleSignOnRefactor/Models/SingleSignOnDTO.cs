using System;
namespace SingleSignOnRefactor.Models
{
    public class SingleSignOnDTO
    {
        public int Id { get; set; }
        public string? AzureId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

