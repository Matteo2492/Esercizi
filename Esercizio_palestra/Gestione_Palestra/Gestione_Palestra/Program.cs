using Gestione_Palestra.Models;
using Gestione_Palestra.Repo;
using Gestione_Palestra.Services;
using Microsoft.EntityFrameworkCore;

namespace Gestione_Palestra
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<GestionePalestraContext>(
               options => options.UseSqlServer(
                   builder.Configuration.GetConnectionString("Locale")
                   )
               );
            builder.Services.AddScoped<UtentiRepo>();
            builder.Services.AddScoped<UtentiService>();
            builder.Services.AddScoped<CorsiRepo>();
            builder.Services.AddScoped<CorsiService>();
            builder.Services.AddScoped<PrenotazioneRepo>();
            builder.Services.AddScoped<PrenotazioniService>();
            builder.Services.AddScoped<PrenotazioniUtentiRepo>();
            builder.Services.AddScoped<PrenotazioniUtentiService>();

            builder.Services.AddSession(options =>
            { options.IdleTimeout = TimeSpan.FromMinutes(3); }); // IMPORTANTE PER LE SESSIONI!!!!!

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

            app.UseSession(); // ABILITO LE SESSIONE!!!!

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authsess}/{action=Login}/{varCodice?}/{varUtente?}");

            app.Run();
        }
    }
}
