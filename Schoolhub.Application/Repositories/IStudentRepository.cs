using Schoolhub.Application.Students;
using Schoolhub.Domain.Students;

namespace Schoolhub.Application.Repositories;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> ExistsByIdentifierAsync(string identifier, CancellationToken ct = default);
    Task AddAsync(Student student, CancellationToken ct = default);
    Task UpdateAsync(Student s, CancellationToken ct = default);
    Task DeleteAsync(Student student, CancellationToken ct = default);

    Task<StudentDto?> GetAsync(Guid id, CancellationToken ct = default);
    Task<List<StudentDto>> ListAsync(CancellationToken ct = default);
    Task<int> CountInClassAsync(Guid classId, CancellationToken ct = default);
}