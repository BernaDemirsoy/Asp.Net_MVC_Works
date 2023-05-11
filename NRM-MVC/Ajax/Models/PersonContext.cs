using Microsoft.EntityFrameworkCore;

namespace Ajax.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public PersonContext(DbContextOptions<PersonContext> db) : base(db)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(a => a.Id).IsRequired();
            modelBuilder.Entity<Person>().HasKey(a => a.Id);
            modelBuilder.Entity<Person>().HasData(
             new Person()
             {
                 Id = 1,
                 FirstName = "Arda",
                 LastName = "Şen"
             },
             new Person()
             {
                 Id = 2,
                 FirstName = "John",
                 LastName = "Doe"
             },
              new Person()
              {
                  Id = 3,
                  FirstName = "Jane",
                  LastName = "Doe"
              });
        }
    }
}
