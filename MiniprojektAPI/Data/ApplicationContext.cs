using MiniprojektAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniprojektAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        //Since using a many to many connection, needed this to make it keyless
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>().HasKey(pi => new { pi.PersonId, pi.InterestId });
        }
    }
}
