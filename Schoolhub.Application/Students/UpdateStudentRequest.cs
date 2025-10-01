namespace Schoolhub.Application.Students;

public class UpdateStudentRequest
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateOnly? DateOfBirth { get; init; }

    public string? City { get; init; }
    public string? Street { get; init; }
    public string? PostalCode { get; init; }
}