using Schoolhub.Domain.Students;

namespace Schoolhub.Domain.Classes;

public class SchoolClass
{
    public const int MaxStudents = 2;

    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string LeadTeacher { get; private set; }
    public ICollection<Student> Students { get; } = new List<Student>();

    private SchoolClass() { }

    private SchoolClass(string name, string leadTeacher)
    {
        Name = name;
        LeadTeacher = leadTeacher;
    }

    public static SchoolClass Create(string name, string leadTeacher)
    {
        return new SchoolClass(name, leadTeacher);
    }

    public void Update(string name, string leadTeacher)
    {
        Name = name;
        LeadTeacher = leadTeacher;
    }
}