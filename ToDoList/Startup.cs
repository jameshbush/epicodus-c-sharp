using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ToDoList
{
  public class Startup
  {
    public Startup(IHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();

      app.UseDeveloperExceptionPage();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapRazorPages();
      });
    }
  }

  public static class DbConfiguration
  {
    public static string ConnectionString = "Server=localhost;user id=root;password=pw;port=336;database=to_do_list";
  }
}