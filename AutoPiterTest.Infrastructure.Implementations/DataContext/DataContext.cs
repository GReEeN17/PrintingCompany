using AutoPiterTest.Infrastructure.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AutoPiterTest.Infrastructure.Implementations.DataContext;

public class DataContext : DbContext
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<BranchPrintingDevice> BranchPrintingDevices { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MacAddress> MacAddresses { get; set; }
    public DbSet<PrintingDevice> PrintingDevices { get; set; }
    public DbSet<PrintingDeviceMacAddress> PrintingDevicesMacAddresses { get; set; }
    public DbSet<PrintingTask> PrintingTasks { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Branch config
        
        modelBuilder.Entity<Branch>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
        
        #region BranchPrintingDevice config
        
        modelBuilder.Entity<BranchPrintingDevice>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
        
        #region Employee config
        
        modelBuilder.Entity<Employee>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
        
        #region MacAddress config
        
        modelBuilder.Entity<MacAddress>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
        
        #region PrintingDevice config
        
        modelBuilder.Entity<PrintingDevice>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
        
        #region PrintingDeviceMacAddress config
        
        modelBuilder.Entity<PrintingDeviceMacAddress>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
        
        #region PrintingTask config
        
        modelBuilder.Entity<PrintingTask>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();
        
        #endregion
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
    
    public DbSet<T> DbSet<T>() where T : class
    {
        return Set<T>();
    }
    
    public new IQueryable<T> Query<T>() where T : class
    {
        return Set<T>();
    }
}