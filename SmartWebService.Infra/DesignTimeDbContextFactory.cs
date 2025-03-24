using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SmartWebService.Infra;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbContextInfra>
{
    public DbContextInfra CreateDbContext(string[] args)
    {
        string configPath = "./SmartWebService/SmartWebService/SmartWebService.Presentation/appsettings.json";
        
        if (!File.Exists(configPath))
        {
            throw new InvalidOperationException($"Arquivo de configuração não encontrado em: {configPath}");
        }
        
        Console.WriteLine($"Usando arquivo de configuração em: {configPath}");
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(configPath))
            .AddJsonFile(Path.GetFileName(configPath), optional: false)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<DbContextInfra>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada no appsettings.json");
        }
        
        optionsBuilder.UseNpgsql(connectionString);
        
        return new DbContextInfra(optionsBuilder.Options);
    }
}