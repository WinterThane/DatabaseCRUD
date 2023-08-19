using DatabaseCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCRUD.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
