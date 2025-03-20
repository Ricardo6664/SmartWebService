using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Microsoft.Extensions.Configuration;
=======
>>>>>>> origin/main
using SmartWebService.Domain;

namespace SmartWebService.Infra;

public class DbContextInfra: DbContext
{
    public DbSet<User> Users { get; set; }
    
<<<<<<< HEAD
    private readonly IConfiguration _configuration;
    
    public DbContextInfra(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbContextInfra()
    {
        throw new NotImplementedException();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
=======
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=database_web_service;Username=postgres;Password=admin");
>>>>>>> origin/main
    }
}