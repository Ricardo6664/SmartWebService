using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartWebService.Domain;

namespace SmartWebService.Infra;

public class DbContextInfra: DbContext
{
    public DbSet<User> Users { get; set; }
    
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
    }
}