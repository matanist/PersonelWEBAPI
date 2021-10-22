using Microsoft.EntityFrameworkCore;

namespace PERSONELWEBAPI.Data
{
    public class PersonelDBContext : DbContext
    {
        public PersonelDBContext(DbContextOptions<PersonelDBContext> options) : base(options)
        {  
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }

    }
}