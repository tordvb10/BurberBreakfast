using BuberBreakfast.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BuberBreakfast.Services.Breakfasts;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService,breakfastService>();

    string sqlConnectionStringtest = Environment.GetEnvironmentVariable("SQLEXPRESS_DB_LOCAL");
    Console.WriteLine($"{sqlConnectionStringtest}Database=FirstDBselfTEST;");
    string sqlConnectionString = $"{Environment.GetEnvironmentVariable("SQLEXPRESS_DB_LOCAL")}Database=BuberBreakfastDb;";
    Console.WriteLine( sqlConnectionString );
    if (string.IsNullOrEmpty(sqlConnectionString))
    {
        throw new InvalidOperationException("The environment variable 'SQLEXPRESS_DB_LOCAL' is not set.");
    }
    builder.Services.AddDbContext<YourDbContext>(options =>
    {
        options.UseSqlServer(sqlConnectionString);
    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

