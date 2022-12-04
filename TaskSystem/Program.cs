using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.repositories;
using TaskSystem.repositories.Interfaces;

namespace TaskSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // configurando o entityframework
        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<TaskSystemDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

        // resolvendo as injeções de dependência
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        var app = builder.Build();

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