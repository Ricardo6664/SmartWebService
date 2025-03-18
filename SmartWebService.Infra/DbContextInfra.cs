using Microsoft.EntityFrameworkCore;
using SmartWebService.Domain;

namespace SmartWebService.Infra;

public class DbContextInfra: DbContext
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=database_web_service;Username=postgres;Password=admin");
    }
}