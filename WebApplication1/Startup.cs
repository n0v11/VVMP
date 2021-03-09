using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Library;
using Microsoft.AspNetCore.Http;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            using ApplicationsContext context = new ApplicationsContext();
            context.Database.EnsureCreated();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationsContext>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ��������� ������ HTTP
            app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            app.Map("/error", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync($"Error: {context.Request.Query["code"]}");
            }));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
