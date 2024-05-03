
using MarioKart.Controllers;
using MarioKart.Models;
using MarioKart.Repos;
using MarioKart.Services;
using Microsoft.EntityFrameworkCore;

namespace MarioKart
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
            

            #region Importanti per la configurazione di Context e Repository
            builder.Services.AddDbContext<MarioContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<PersonaggioRepo>();
            builder.Services.AddScoped<SquadraRepo>();
            builder.Services.AddScoped<PersonaggioService>();
            builder.Services.AddScoped<SquadraService>();
            builder.Services.AddScoped<PersonaggioController>();
            builder.Services.AddScoped<SquadraController>();

            #endregion

            var app = builder.Build();

            app.UseCors(builder =>
                builder
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
