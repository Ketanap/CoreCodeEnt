using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreEnt.Models
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext()
        { }
        public CoreDBContext(DbContextOptions<CoreDBContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("MvcCoreDBContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblContact> tblContact { get; set; }
    }
}
