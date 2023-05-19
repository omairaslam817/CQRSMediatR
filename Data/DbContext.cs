using CQRSMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Data
{
    public class ApplicationDbContext:DbContext //ORM
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
