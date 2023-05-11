using CodeFirst.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<School>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Lesson>().ToTable("Dersler");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
