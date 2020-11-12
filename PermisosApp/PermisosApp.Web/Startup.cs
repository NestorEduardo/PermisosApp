using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PermisosApp.Data;
using PermisosApp.Repository.Abstract;
using PermisosApp.Repository.Implementations;
using PermisosApp.Services.Abstract;
using PermisosApp.Services.Implementations;
using PermisosApp.Web.Configuration;
using System;

namespace PermisosApp.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPermissionTypeService, PermissionTypeService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddControllers();
            string dbConnString = Configuration["Data:PermisosApp:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnString, builder => builder.MigrationsAssembly(typeof(Startup).Assembly.FullName)));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DbInitializer.Seed(serviceProvider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
