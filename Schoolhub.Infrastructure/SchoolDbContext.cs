using Microsoft.EntityFrameworkCore;
using Schoolhub.Domain.Classes;
using Schoolhub.Domain.Students;

namespace Schoolhub.Infrastructure;

public class SchoolDbContext(DbContextOptions<SchoolDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }

    public DbSet<SchoolClass> SchoolClasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(b =>
        {
            b.HasKey(s => s.Id);

            b.OwnsOne(s => s.StudentIdentifier, si =>
            {
                si.Property(p => p.Value).IsRequired();
                si.HasIndex(p => p.Value).IsUnique();
            });

            b.OwnsOne(s => s.Address);

            b.HasOne<SchoolClass>()          
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.SchoolClassId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<SchoolClass>(b =>
        {
            b.HasKey(c => c.Id);

            b.Property(c => c.Name)
                .IsRequired();

            b.Property(c => c.LeadTeacher)
                .IsRequired();

        });
    }
}