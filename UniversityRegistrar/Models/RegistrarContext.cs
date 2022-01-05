using Microsoft.EntityFrameworkCore;

namespace Registrar.Models
{
  public class RegistrarContext: DbContext
  {
    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get;set;}
    public DbSet<Department> Departments {get; set;}
    public DbSet<CourseStudent> CourseStudent {get; set;}
    public DbSet<CourseDepartment> CourseDepartment {get; set;}
    public DbSet<DepartmentStudent> DepartmentStudent {get; set;}
    public RegistrarContext(DbContextOptions options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}