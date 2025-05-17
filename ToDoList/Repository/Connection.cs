using Microsoft.EntityFrameworkCore;
using ToDoList.Mappings;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class Connection : DbContext
    {

        public DbSet<Models.Task> tasks { get; set; }
        public DbSet<Models.TaskStatus> taskStatus { get; set; }
        public DbSet<Models.UrgencyLevel> urgencyLevel { get; set; }

        public Connection() { }
        public Connection(DbContextOptions<Connection> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Connection).Assembly);
        }
    }
}
