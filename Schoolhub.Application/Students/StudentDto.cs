namespace Schoolhub.Application.Students;

public record StudentDto(
    Guid id,
    string StudentIdentifier,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string? City,
    string? Street,
    string? PostalCode
);