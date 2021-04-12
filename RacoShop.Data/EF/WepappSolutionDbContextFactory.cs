using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RacoShop.Data.EF
{
    public class WepappSolutionDbContextFactory : IDesignTimeDbContextFactory<RacoShopDBContext>
    {
        public RacoShopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("RacoShopSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<RacoShopDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new RacoShopDBContext(optionsBuilder.Options);
        }
    }
}
