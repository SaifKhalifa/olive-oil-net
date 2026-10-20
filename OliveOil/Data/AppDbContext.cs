using Microsoft.EntityFrameworkCore;
using OliveOil.Models;

namespace OliveOil.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<OliveOilProduct> OliveOilProducts => Set<OliveOilProduct>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OliveOilProduct>().HasData
            (
                new OliveOilProduct { Id = 1 ,Name = "nablus oil - 1", PricePerLiter = 99, QuantityInStock = 10, Region = "nablus" },
                new OliveOilProduct { Id = 2, Name = "jenin oil - 2", PricePerLiter = 99, QuantityInStock = 10, Region = "jenin" },
                new OliveOilProduct { Id = 3, Name = "hebron oil - 3", PricePerLiter = 99, QuantityInStock = 10, Region = "hebron" }
            );

    }

}
