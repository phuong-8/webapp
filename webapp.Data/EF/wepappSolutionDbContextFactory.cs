using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace webapp.Data.EF
{
    public class wepappSolutionDbContextFactory : IDesignTimeDbContextFactory<webappDBContext>
    {
        public webappDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("webappSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<webappDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new webappDBContext(optionsBuilder.Options);
        }
    }
}
