
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using User.Domain.User.Model;
using User.Infra.Data.User.Mappings;

namespace Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() {

        }

        public DatabaseContext(DbContextOptions options)
            : base(options) {
        }
        
        public DbSet<Users> Flags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
           

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
#endif


            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //config.Workarounds.DisableQuoting = true;

            var sqlConnection = config.GetConnectionString("DefaultConnection");

            SqlConnection conn = new SqlConnection(sqlConnection);


            optionsBuilder.UseSqlServer(conn);
        }
    }
}
