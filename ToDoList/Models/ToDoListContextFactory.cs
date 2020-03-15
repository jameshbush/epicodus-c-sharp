using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ToDoList.Models
{
  public class ToDoListContextFactory : IDesignTimeDbContextFactory<ToDoListContext>
  {
    ToDoListContext IDesignTimeDbContextFactory<ToDoListContext>.CreateDbContext(string[] args)
    {
      var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<ToDoListContext>();
      var connectionString = configuration.GetConnectionString("Default Connection");

      builder.UseMySql(connectionString);

      return new ToDoListContext(builder.Options);
    }
  }
}