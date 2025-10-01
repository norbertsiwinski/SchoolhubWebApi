using Schoolhub.Application.Common;
using Schoolhub.Domain.Classes;
using Schoolhub.Domain.Students;
using Schoolhub.Application.Repositories;

namespace Schoolhub.Application.Classes;

public class ClassService(IStudentRepository studentRepository, IClassRepository classRepository) : IClassService
{
    public async Task AssignStudentToClassAsync(Guid studentId, Guid classId, CancellationToken ct = default)
    {
        var c = await classRepository.GetByIdAsync(classId, ct) 
                ?? throw new NotFoundException(nameof(SchoolClass), classId.ToString());

        var student = await studentRepository.GetByIdAsync(studentId, ct) 
                      ?? throw new NotFoundException(nameof(Student), studentId.ToString());

        if (student.SchoolClassId == classId)
            throw new StudentAlreadyInClassException(studentId, classId);

        if (student.SchoolClassId is not null)
            throw new StudentAlreadyInClassException(studentId, student.SchoolClassId.Value);

        var count = await studentRepository.CountInClassAsync(classId, ct);
        if (count >= SchoolClass.MaxStudents)
            throw new ClassIsFullException(classId, SchoolClass.MaxStudents);

        student.AssignToClass(classId);
        await studentRepository.UpdateAsync(student, ct);
    }

    public async Task UnassignStudentFromClassAsync(Guid studentId, CancellationToken ct = default)
    {
        var student = await studentRepository.GetByIdAsync(studentId, ct) 
                      ?? throw new NotFoundException(nameof(Student), studentId.ToString());

        student.RemoveFromClass();
        await studentRepository.UpdateAsync(student, ct);
    }

    public async Task<Guid> CreateAsync(CreateSchoolClassRequest req, CancellationToken ct = default)
    {
        var c = SchoolClass.Create(req.Name, req.LeadTeacher);
        await classRepository.AddAsync(c, ct);

        return c.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var c = await classRepository.GetByIdAsync(id, ct);
        if (c is null)
            throw new NotFoundException(nameof(SchoolClass), id.ToString());

        await classRepository.DeleteAsync(c, ct);
    }

    public async Task<SchoolClassDto?> GetAsync(Guid id, CancellationToken ct = default) =>
        await classRepository.GetAsync(id, ct) ??
        throw new NotFoundException(nameof(SchoolClass), id.ToString());

    public async Task<List<SchoolClassDto>> ListAsync(CancellationToken ct = default) =>
        await classRepository.ListAsync(ct);


    public async Task UpdateAsync(Guid id, UpdateSchoolClassRequest request, CancellationToken ct = default)
    {
        var c = await classRepository.GetByIdAsync(id, ct);
        if (c is null)
            throw new NotFoundException(nameof(SchoolClass), id.ToString());

        var newName = request.Name ?? c.Name;
        var newLead = request.LeadTeacher ?? c.LeadTeacher;

        c.Update(newName, newLead);
        await classRepository.UpdateAsync(c, ct);
    }
}