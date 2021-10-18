using ContactBook.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Data
{
    public class ContactBookDbContext : DbContext, IContactBookDbContext
    {
        public ContactBookDbContext(DbContextOptions<ContactBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonLocation> PersonsLocations { get; set; }
    }
}
