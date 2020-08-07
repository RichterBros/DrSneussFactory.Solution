using Microsoft.EntityFrameworkCore;

namespace DrSneuss.Models
{
  public class DrSneussContext : DbContext
  {
    public virtual DbSet<Machine> Machines { get; set; }

    public DbSet<Engineer> Engineers { get; set;}
    public DbSet<EngineerMachine> EngineerMachine { get; set; }

    //public DbSet<Department> Departments {get; set;}
    
    public DrSneussContext(DbContextOptions options) : base(options) {}
  }
}