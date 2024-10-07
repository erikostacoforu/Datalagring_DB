using ConsoleAppDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppDB.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {        
    }

    public DbSet<AddressEntity> Adresses { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<CustomerEntity> Customers { get; set; }

    public DbSet<ManufactureEntity> Manufactures { get; set; }

    public DbSet<ProductEntity> Products { get; set; } 
}
