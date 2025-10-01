namespace Schoolhub.Application.Classes;

public interface IClassService
{
    Task AssignStudentToClassAsync(Guid studentId, Guid classId, CancellationToken ct = default);
    Task UnassignStudentFromClassAsync(Guid studentId, CancellationToken ct = default);

    public Task<Guid> CreateAsync(CreateSchoolClassRequest req, CancellationToken ct = default);
    Task UpdateAsync(Guid id, UpdateSchoolClassRequest student, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);

    Task<List<SchoolClassDto>> ListAsync(CancellationToken ct = default);
    Task<SchoolClassDto?> GetAsync(Guid id, CancellationToken ct = default);

}