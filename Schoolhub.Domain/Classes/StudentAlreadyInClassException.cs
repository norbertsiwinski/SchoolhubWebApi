using Schoolhub.Domain.Common;

namespace Schoolhub.Domain.Classes;

public class StudentAlreadyInClassException(Guid studentId, Guid classId)
    : DomainException($"Student '{studentId}' already in class '{classId}'.");