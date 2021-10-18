using ContactBook.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactBook.Data
{
    public interface IContactBookDbContext
    {
        DbSet<T> Set<T>() where T : class;
        DbSet<Company> Companies { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<PersonLocation> PersonsLocations { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class; // DbService Entity pie Update
        int SaveChanges();
    }
}
