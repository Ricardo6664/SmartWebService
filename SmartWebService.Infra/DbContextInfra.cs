using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartWebService.Domain;

namespace SmartWebService.Infra;

public class DbContextInfra : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<SecuritySystem> SecuritySystems { get; set; }
    
    private readonly IConfiguration _configuration;
    
    public DbContextInfra(DbContextOptions<DbContextInfra> options, IConfiguration configuration) 
        : base(options)
    {
        _configuration = configuration;
    }
    
    public DbContextInfra(DbContextOptions<DbContextInfra> options) 
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration?.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}