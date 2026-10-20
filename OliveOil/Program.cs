using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OliveOil.Data;
using System.Reflection;

namespace OliveOil;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "W4-T1: Olive Oil SQL Injection Test Task",
                Version = "v1",
                Description = "test input: ' OR '1'='1"
            });

            
        });

        builder.Services.AddDbContext<AppDbContext>
            (
                options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

        var app = builder.Build();

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
