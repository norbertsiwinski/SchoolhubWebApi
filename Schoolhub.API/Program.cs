using Microsoft.OpenApi.Models;
using Schoolhub.API.Middlewares;
using Schoolhub.Application.Classes;
using Schoolhub.Application.Extensions;
using Schoolhub.Application.Students;
using Schoolhub.Infrastructure.Extensions;
using Schoolhub.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Schoolhub API",
        Version = "v1"
    });

});
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IStudentService, StudentService>(); 
builder.Services.AddScoped<IClassService, ClassService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var studentSeeder = scope.ServiceProvider.GetRequiredService<IStudentSeeder>();
var classSeeder = scope.ServiceProvider.GetRequiredService<IClassSeeder>();

await studentSeeder.Seed();
await classSeeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
