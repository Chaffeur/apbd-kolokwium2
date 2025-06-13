using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Nursery> Nurseries { get; set; } = null!;
    public DbSet<Responsible> Responsibles { get; set; } = null!;
    public DbSet<Seedling_Batch> Seedling_Batch { get; set; } = null!;
    public DbSet<Tree_Species> Tree_Species { get; set; } = null!;

    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Responsible>().HasKey(e => new { e.BatchId, e.Employee });
        modelBuilder.Entity<Seedling_Batch>().HasOne(e => e.Nursery).WithMany(e => e.Seedling_Batches).HasForeignKey(e => e.NurseryId);
        modelBuilder.Entity<Seedling_Batch>().HasOne(e => e.Species).WithMany(e => e.Seedling_Batches).HasForeignKey(e => e.SpeciesId);
        modelBuilder.Entity<Responsible>().HasOne(e => e.BatchNav).WithMany(e => e.Responsibles).HasForeignKey(e => e.BatchId);
        modelBuilder.Entity<Responsible>().HasOne(e => e.EmployeeNav).WithMany(e => e.Responsibles)
            .HasForeignKey(e => e.Employee);

        modelBuilder.Entity<Employee>().HasData(new Employee
            { EmployeeId = 1, FirstName = "Jan", LastName = "Kowalski", HireDate = new DateTime(2025, 10, 10) });
        modelBuilder.Entity<Nursery>().HasData(new Nursery
            { NurseryId = 1, Name = "test", EstablishedDate = new DateTime(2000, 10, 12) });
        modelBuilder.Entity<Responsible>().HasData(new Responsible { BatchId = 1, Employee = 1, Role = "Admin" });
        modelBuilder.Entity<Models.Seedling_Batch>().HasData(new Models.Seedling_Batch
        {
            BatchId = 1, NurseryId = 1, SpeciesId = 1, Quantity = 10, SownDate = new DateTime(2020, 05, 06),
            ReadyDate = new DateTime(2025, 10, 14)
        });
        modelBuilder.Entity<Tree_Species>().HasData(new Tree_Species
            { SpeciesId = 1, LatinName = "Nazwa", GrowthTimeInYears = 5 });


    }
    
    
}