using Coink.Domain.Entities.Controllers;
using Coink.Domain.Entities.Security.Token;
using Microsoft.EntityFrameworkCore;

namespace Coink.Infrastructure.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<TokenUser> TokenUser { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<City> Citiy { get; set; }
    public DbSet<Department> Department { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Entity>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<TokenUser>().HasNoKey();
        modelBuilder.Entity<City>().HasNoKey();
        modelBuilder.Entity<Country>().HasNoKey();
        modelBuilder.Entity<Department>().HasNoKey();
        modelBuilder.Entity<User>().HasNoKey();
    }
}