using AmoebaApp.Models;
using AmoebaApp.Models.Employee;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmoebaApp.DAL
{
    public class AmoebaDbContext : IdentityDbContext
    {
        public AmoebaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        
    }
}
