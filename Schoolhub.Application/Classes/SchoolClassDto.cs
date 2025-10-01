using Schoolhub.Application.Students;

namespace Schoolhub.Application.Classes;

public record SchoolClassDto(
    Guid id,
    string Name,
    string LeadTeacher,
    List<StudentDto> Students
);