using Schoolhub.Application.Classes;
using Schoolhub.Domain.Classes;

namespace Schoolhub.Application.Repositories;

public interface IClassRepository
{
    Task<SchoolClass?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(SchoolClass c, CancellationToken ct = default);
    Task UpdateAsync(SchoolClass c, CancellationToken ct = default);
    Task DeleteAsync(SchoolClass c, CancellationToken ct = default);

    Task<List<SchoolClassDto>> ListAsync(CancellationToken ct = default);
    Task<SchoolClassDto?> GetAsync(Guid id, CancellationToken ct = default);
}