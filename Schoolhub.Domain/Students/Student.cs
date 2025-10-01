using Schoolhub.Domain.Common;

namespace Schoolhub.Domain.Students;

public class Student
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public StudentIdentifier StudentIdentifier { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Address? Address { get; private set; }
    public Guid? SchoolClassId { get; private set; }

    private Student() { }

    private Student(StudentIdentifier sid, string firstName, string lastName, DateOnly dob,
        Address? address)
    {
        StudentIdentifier = sid;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
        Address = address;
    }

    public static Student Create(StudentIdentifier sid, string firstName, string lastName, DateOnly dob,
        Address? address)
    {
        return new Student(sid, firstName, lastName, dob, address);
    }

    public void Update(string? firstName, string? lastName, DateOnly? dateOfBirth, string? city, string? street, string? postalCode)
    {
        if (firstName != null) FirstName = firstName;
        if (lastName != null) LastName = lastName;
        if (dateOfBirth.HasValue) DateOfBirth = dateOfBirth.Value;

        if (city != null || street != null || postalCode != null)
        {
            Address = new Address(city, street, postalCode);
        }
    }

    public void AssignToClass(Guid classId) => SchoolClassId = classId;

    public void RemoveFromClass() => SchoolClassId = null;
}