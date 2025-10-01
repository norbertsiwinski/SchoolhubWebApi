using Microsoft.EntityFrameworkCore;
using Schoolhub.Application.Repositories;
using Schoolhub.Application.Students;
using Schoolhub.Domain.Students;

namespace Schoolhub.Infrastructure.Repositories;

public class StudentRepository(SchoolDbContext schoolDbContext) : IStudentRepository
{
    public async Task<Student?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await schoolDbContext.Students
            .FirstOrDefaultAsync(s => s.Id == id, ct);

    public Task<bool> ExistsByIdentifierAsync(string identifier, CancellationToken ct = default) =>
        schoolDbContext.Students.AsNoTracking()
            .AnyAsync(s => s.StudentIdentifier.Value == identifier, ct);

    public async Task AddAsync(Student student, CancellationToken ct = default)
    {
        await schoolDbContext.Students.AddAsync(student, ct);
        await schoolDbContext.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Student student, CancellationToken ct = default)
    {
        schoolDbContext.Students.Update(student);
        await schoolDbContext.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Student student, CancellationToken ct = default)
    {
        schoolDbContext.Students.Remove(student);
        await schoolDbContext.SaveChangesAsync(ct);
    }

    public Task<StudentDto?> GetAsync(Guid id, CancellationToken ct = default)
    {
        return schoolDbContext.Students.AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new StudentDto(
                s.Id,
                s.StudentIdentifier.Value,
                s.FirstName,
                s.LastName,
                s.DateOfBirth,
                s.Address != null ? s.Address.City : null,
                s.Address != null ? s.Address.Street : null,
                s.Address != null ? s.Address.PostalCode : null
            ))
            .SingleOrDefaultAsync(ct);
    }

    public Task<List<StudentDto>> ListAsync(CancellationToken ct = default)
    {
        return schoolDbContext.Students
            .AsNoTracking()
            .OrderBy(s => s.LastName).ThenBy(s => s.FirstName)
            .Select(s => new StudentDto(
                s.Id,
                s.StudentIdentifier.Value,
                s.FirstName,
                s.LastName,
                s.DateOfBirth,
                s.Address != null ? s.Address.City : null,
                s.Address != null ? s.Address.Street : null,
                s.Address != null ? s.Address.PostalCode : null
            ))
            .ToListAsync(ct);
    }

    public Task<int> CountInClassAsync(Guid classId, CancellationToken ct = default) => 
        schoolDbContext.Students
            .AsNoTracking()
            .CountAsync(s => s.SchoolClassId == classId, ct);
}