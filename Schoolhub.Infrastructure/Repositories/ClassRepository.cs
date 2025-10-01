
using Microsoft.EntityFrameworkCore;
using Schoolhub.Application.Classes;
using Schoolhub.Application.Repositories;
using Schoolhub.Application.Students;
using Schoolhub.Domain.Classes;

namespace Schoolhub.Infrastructure.Repositories;

public  class ClassRepository(SchoolDbContext schoolDbContext) : IClassRepository
{
    public Task<SchoolClass?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => schoolDbContext.SchoolClasses.FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task AddAsync(SchoolClass c, CancellationToken ct = default)
    {
        await schoolDbContext.SchoolClasses.AddAsync(c, ct); 
        await schoolDbContext.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(SchoolClass c, CancellationToken ct = default)
    {
        schoolDbContext.SchoolClasses.Update(c); 
        await schoolDbContext.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(SchoolClass c, CancellationToken ct = default)
    {
        schoolDbContext.SchoolClasses.Remove(c); 
        await schoolDbContext.SaveChangesAsync(ct);
    }

    public Task<List<SchoolClassDto>> ListAsync(CancellationToken ct = default)
        => schoolDbContext.SchoolClasses.AsNoTracking()
            .Select(c => new SchoolClassDto(
                c.Id,
                c.Name,
                c.LeadTeacher,
                c.Students
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
                    .ToList()
            ))
            .ToListAsync(ct);


    public Task<SchoolClassDto?> GetAsync(Guid id, CancellationToken ct = default)
        => schoolDbContext.SchoolClasses
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new SchoolClassDto(
                c.Id,
                c.Name,
                c.LeadTeacher,
                c.Students
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
                    .ToList()
            ))
            .SingleOrDefaultAsync(ct);

}