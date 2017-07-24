using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebDemo.Model;
using Microsoft.EntityFrameworkCore;
using WebDemo.Module;
using WebDemo.Services;

namespace WebDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDbContext<zModel>(options => options.UseSqlServer(Configuration.GetConnectionString("WebDemoDB")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepositoryCollection), typeof(RepositoryCollection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            clsEntity.db = app.ApplicationServices.GetService<zModel>();
            DbInitializer.Initialize(clsEntity.db);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Admin_Home", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "Default_Home", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
