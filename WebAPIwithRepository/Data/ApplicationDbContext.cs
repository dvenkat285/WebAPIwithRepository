using Microsoft.EntityFrameworkCore;
using WebAPIwithRepository.Models;

namespace WebAPIwithRepository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
    
    public virtual DbSet<Patient> Patients { get; set; }
    }
}
