using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupplySyncBackend.Data;
using Microsoft.EntityFrameworkCore;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Services;

namespace SupplySyncBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAnalyticsService, AnalyticsService>();
            services.AddScoped<IAIService, AIService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISupplierService, SupplierService>();

            // Add more services as required
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
