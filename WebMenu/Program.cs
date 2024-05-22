using MenuItems.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace WebMenu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //create IConfigureation variable
            IConfiguration configuration = new ConfigurationBuilder() //making configuration object to register the json connection. 
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build();
            //Create instance of MenuItemsContext to use assigned connections string.  
            builder.Services.AddDbContext<MenuItemsContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(name:"defaultConnection")) ;
                }
                );
                
            //services.AddSingleton<ISQLFundamentalsConfigManager, SQLFundamentalsConfigManager>(); For ADO.NET
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
