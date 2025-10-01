using Schoolhub.Domain.Common;

namespace Schoolhub.Domain.Classes;

public class ClassIsFullException(Guid classId, int maxStudents) 
    : DomainException($"Class '{classId}' is full (max {maxStudents}).");