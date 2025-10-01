using System.ComponentModel.DataAnnotations;

namespace Schoolhub.Application.Students
{
    public class CreateStudentRequest
    {
        [Required]
        public string StudentIdentifier { get; init; } = default!;

        [Required]
        public string FirstName { get; init; } = default!;

        [Required]
        public string LastName { get; init; } = default!;

        [Required]
        public DateOnly DateOfBirth { get; init; }

        public string? City { get; init; }
        public string? Street { get; init; }
        public string? PostalCode { get; init; }
    }
}
