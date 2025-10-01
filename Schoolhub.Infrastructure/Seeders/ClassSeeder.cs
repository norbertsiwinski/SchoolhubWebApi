using Schoolhub.Domain.Classes;

namespace Schoolhub.Infrastructure.Seeders;

internal class ClassSeeder(SchoolDbContext dbContext) : IClassSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.SchoolClasses.Any())
            {
                var classes = GetSchoolClasses();
                dbContext.SchoolClasses.AddRange(classes);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private static List<SchoolClass> GetSchoolClasses() => new()
    {
        SchoolClass.Create("1A", "Jan Kowalski"),
        SchoolClass.Create("1B", "Maria Walczak"),
    };
}