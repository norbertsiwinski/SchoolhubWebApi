using Schoolhub.Application.Common;
using Schoolhub.Application.Repositories;
using Schoolhub.Domain.Common;
using Schoolhub.Domain.Students;

namespace Schoolhub.Application.Students;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public async Task<Guid> CreateAsync(CreateStudentRequest req, CancellationToken ct = default)
    {
        var sid = StudentIdentifier.Create(req.StudentIdentifier);
        var student = Student.Create(
            sid,
            req.FirstName, 
            req.LastName, 
            req.DateOfBirth,
            new Address(req.City, req.Street, req.PostalCode)
        );

        if (await studentRepository.ExistsByIdentifierAsync(sid.Value, ct))
            throw new InvalidOperationException("Student identifier must be unique.");

        await studentRepository.AddAsync(student, ct);
        return student.Id;
    }

    public async Task UpdateAsync(Guid id, UpdateStudentRequest req, CancellationToken ct = default)
    {
        var s = await studentRepository.GetByIdAsync(id, ct);
        if (s is null)
            throw new NotFoundException(nameof(Student), id.ToString());

        s.Update(req.FirstName, req.LastName, req.DateOfBirth, req.City, req.Street, req.PostalCode);

        await studentRepository.UpdateAsync(s, ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var s = await studentRepository.GetByIdAsync(id, ct);
        if (s is null)
            throw new NotFoundException(nameof(Student), id.ToString());

        await studentRepository.DeleteAsync(s, ct);
    }

    public async Task<List<StudentDto>> ListAsync(CancellationToken ct = default) => 
        await studentRepository.ListAsync(ct);
    
    public async Task<StudentDto?> GetAsync(Guid id, CancellationToken ct = default) => 
        await studentRepository.GetAsync(id, ct) 
        ?? throw new NotFoundException(nameof(Student), id.ToString());

}