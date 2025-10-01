using Schoolhub.Domain.Students;

namespace Schoolhub.Application.Students;

public interface IStudentService
{
    public Task<Guid> CreateAsync(CreateStudentRequest req, CancellationToken ct = default);
    Task UpdateAsync(Guid id, UpdateStudentRequest student, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);

    Task<List<StudentDto>> ListAsync(CancellationToken ct = default);
    Task<StudentDto?> GetAsync(Guid id, CancellationToken ct = default);
}