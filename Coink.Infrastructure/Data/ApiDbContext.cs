using Coink.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coink.Infrastructure.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Entity>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<User>().HasNoKey();
    }
}