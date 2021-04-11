using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace webapp.Data.EF
{
    public class wepappSolutionDbContextFactory : IDesignTimeDbContextFactory<WebappDBContext>
    {
        public WebappDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("webappSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<WebappDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new WebappDBContext(optionsBuilder.Options);
        }
    }
}
