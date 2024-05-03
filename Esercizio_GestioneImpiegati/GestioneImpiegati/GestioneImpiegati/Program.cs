using GestioneImpiegati.Models;
using GestioneImpiegati.Repo;
using GestioneImpiegati.Services;
using Microsoft.EntityFrameworkCore;

namespace GestioneImpiegati
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AccLez35GestioneImpiegatiContext>(
               options => options.UseSqlServer(
                   builder.Configuration.GetConnectionString("Locale")
                   )
               );
            
            builder.Services.AddScoped<ProvinciaRepo>();
            builder.Services.AddScoped<CittaRepo>();
            builder.Services.AddScoped<RepartoRepo>();
            builder.Services.AddScoped<ImpiegatoRepo>();
            builder.Services.AddScoped<ProvinciaService>();
            builder.Services.AddScoped<CittaService>();
            builder.Services.AddScoped<RepartoService>();
            builder.Services.AddScoped<ImpiegatoService>();

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
                pattern: "{controller=Home}/{action=Index}/{varCodice?}");

            app.Run();
        }
    }
}
