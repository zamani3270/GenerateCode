using GenerateCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Repository
{
    public class ApplicationDbContext : DbContext
    {
        #region dbSet
        public DbSet<URLInfo> URLInfo { get; set; }
        public DbSet<RequestLog> RequestLog { get; set; }
        #endregion dbSet
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            base.OnModelCreating(builder);
            SetMappers(builder);

        }
        private void SetMappers(ModelBuilder builder)
        {
            #region SetMapper
            new URLInfoMapper(builder.Entity<URLInfo>().ToTable("URLInfo", "dbo"));
            new RequestLogMapper(builder.Entity<RequestLog>().ToTable("RequestLog", "dbo"));
            #endregion
        }
    }
}
