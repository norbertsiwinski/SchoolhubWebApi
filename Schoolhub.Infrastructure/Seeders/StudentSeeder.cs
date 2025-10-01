using Schoolhub.Domain.Common;
using Schoolhub.Domain.Students;

namespace Schoolhub.Infrastructure.Seeders;

internal class StudentSeeder(SchoolDbContext dbContext) : IStudentSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Students.Any())
            {
                var restaurants = GetStudents();
                dbContext.Students.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
       
        }
    }
    private static List<Student> GetStudents() => new()
{
    Student.Create(
        StudentIdentifier.Create("S001"),
        "Jan", "Kowalski",
        new DateOnly(2010, 5, 1),
        new Address("Warszawa", "Prosta 1", "00-001")
    ),
    Student.Create(
        StudentIdentifier.Create("S002"),
        "Anna", "Nowak",
        new DateOnly(2011, 3, 15),
        new Address("Kraków", "Długa 10", "31-000")
    ),
    Student.Create(
        StudentIdentifier.Create("S003"),
        "Piotr", "Zieliński",
        new DateOnly(2009, 11, 23),
        null
    ),
    Student.Create(
        StudentIdentifier.Create("S004"),
        "Maria", "Wiśniewska",
        new DateOnly(2010, 8, 12),
        new Address("Gdańsk", "Długa 5", "80-887")
    ),
    Student.Create(
        StudentIdentifier.Create("S005"),
        "Katarzyna", "Wójcik",
        new DateOnly(2011, 1, 9),
        new Address("Poznań", "Święty Marcin 12", "61-803")
    ),
    Student.Create(
        StudentIdentifier.Create("S006"),
        "Tomasz", "Kamiński",
        new DateOnly(2010, 6, 30),
        null
    ),
    Student.Create(
        StudentIdentifier.Create("S007"),
        "Agnieszka", "Lewandowska",
        new DateOnly(2012, 2, 18),
        new Address("Wrocław", "Kazimierza Wielkiego 2", "50-077")
    ),
    Student.Create(
        StudentIdentifier.Create("S008"),
        "Michał", "Dąbrowski",
        new DateOnly(2009, 9, 5),
        new Address("Łódź", "Piotrkowska 100", "90-004")
    ),
    Student.Create(
        StudentIdentifier.Create("S009"),
        "Paweł", "Kozłowski",
        new DateOnly(2011, 12, 21),
        null
    ),
    Student.Create(
        StudentIdentifier.Create("S010"),
        "Krzysztof", "Jankowski",
        new DateOnly(2010, 4, 7),
        new Address("Szczecin", "Aleja Wojska Polskiego 15", "70-470")
    ),
    Student.Create(
        StudentIdentifier.Create("S011"),
        "Łukasz", "Mazur",
        new DateOnly(2012, 7, 3),
        new Address("Bydgoszcz", "Gdańska 25", "85-005")
    ),
    Student.Create(
        StudentIdentifier.Create("S012"),
        "Wojciech", "Krawczyk",
        new DateOnly(2009, 10, 14),
        null
    ),
    Student.Create(
        StudentIdentifier.Create("S013"),
        "Natalia", "Kaczmarek",
        new DateOnly(2011, 5, 26),
        new Address("Lublin", "Krakowskie Przedmieście 8", "20-002")
    ),
    Student.Create(
        StudentIdentifier.Create("S014"),
        "Julia", "Piotrowska",
        new DateOnly(2010, 3, 2),
        new Address("Katowice", "Mariacka 3", "40-014")
    ),
    Student.Create(
        StudentIdentifier.Create("S015"),
        "Zuzanna", "Grabowska",
        new DateOnly(2012, 9, 19),
        null
    ),
    Student.Create(
        StudentIdentifier.Create("S016"),
        "Aleksander", "Nowicki",
        new DateOnly(2009, 1, 28),
        new Address("Białystok", "Lipowa 20", "15-424")
    ),
    Student.Create(
        StudentIdentifier.Create("S017"),
        "Oliwia", "Pawlak",
        new DateOnly(2011, 8, 6),
        new Address("Rzeszów", "3 Maja 7", "35-030")
    ),
    Student.Create(
        StudentIdentifier.Create("S018"),
        "Szymon", "Zając",
        new DateOnly(2010, 12, 11),
        null
    ),
    Student.Create(
        StudentIdentifier.Create("S019"),
        "Maja", "Król",
        new DateOnly(2012, 6, 4),
        new Address("Toruń", "Szeroka 11", "87-100")
    ),
};

}