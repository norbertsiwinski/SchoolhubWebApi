using System.ComponentModel.DataAnnotations;

namespace Schoolhub.Application.Classes;

public class CreateSchoolClassRequest
{
    [Required]
    public string Name { get; init; } = default!;

    [Required]
    public string LeadTeacher { get; init; } = default!;
}