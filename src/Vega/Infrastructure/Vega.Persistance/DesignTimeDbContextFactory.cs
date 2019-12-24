﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vega.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VegaDbContext>
    {
        public VegaDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../../Vega.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<VegaDbContext>();
            var connectionString = configuration.GetConnectionString("VegaConnectionString");
            builder.UseSqlServer(connectionString);
            return new VegaDbContext(builder.Options);
        }
    }
}
