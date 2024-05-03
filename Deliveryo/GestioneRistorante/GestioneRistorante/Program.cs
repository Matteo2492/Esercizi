
using GestioneRistorante.Models;
using GestioneRistorante.Repo;
using GestioneRistorante.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestioneRistorante
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DeliveryoContext>(
               options => options.UseSqlServer(
                   builder.Configuration.GetConnectionString("Locale")
                   )
               );

            builder.Services.AddScoped<UtenteRepo>();
            builder.Services.AddScoped<UtenteService>();
            builder.Services.AddScoped<RistoranteRepo>();
            builder.Services.AddScoped<RistoranteService>();
            builder.Services.AddScoped<MenuRepo>();
            builder.Services.AddScoped<MenuService>();
            builder.Services.AddScoped<PiattoRepo>();
            builder.Services.AddScoped<PiattoService>();
            builder.Services.AddScoped<OrdiniRepo>();
            builder.Services.AddScoped<OrdiniService>();

            builder.Services.AddAuthentication()
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = "TeamFantastici",
                   ValidAudience = "Utenti",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"))
               };
           });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(builder =>
             builder
             .WithOrigins("*")
             .AllowAnyMethod()
             .AllowAnyHeader());


            app.MapControllers();

            app.Run();
        }
    }
}
