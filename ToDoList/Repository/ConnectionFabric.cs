using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ToDoList.Repository; 

public class ConnectionFactory : IDesignTimeDbContextFactory<Connection>
{
    public Connection CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Connection>();

        var builder = WebApplication.CreateBuilder(args);
        optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

        return new Connection(optionsBuilder.Options);
    }
}