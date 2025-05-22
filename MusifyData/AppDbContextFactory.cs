using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MusifyData
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "cp3-dotnet");
            Console.WriteLine($"BasePath usado: {basePath}");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine($"Connection string obtida: {connectionString ?? "NULL"}");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string não encontrada! Verifique o caminho e o appsettings.json.");
            }

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseOracle(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
