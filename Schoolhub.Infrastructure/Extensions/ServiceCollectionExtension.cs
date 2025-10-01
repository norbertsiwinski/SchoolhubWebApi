using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schoolhub.Application.Repositories;
using Schoolhub.Infrastructure.Repositories;
using Schoolhub.Infrastructure.Seeders;

namespace Schoolhub.Infrastructure.Extensions;

public static class ServiceCollectionsExtenstion
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SchoolDbContext>(opt => opt.UseInMemoryDatabase("InMemory"));
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IStudentSeeder, StudentSeeder>();
        services.AddScoped<IClassSeeder, ClassSeeder>();
    }
}