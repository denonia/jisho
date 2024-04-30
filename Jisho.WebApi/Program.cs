using Jisho.WebApi.Data;
using Jisho.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace Jisho.WebApi;

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
        
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<WeblioParser>();
        builder.Services.AddScoped<ReversoService>();
        builder.Services.AddScoped<TatoebaService>();
        builder.Services.AddScoped<DictionaryService>();

        builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();
        
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<YomichanDictionarySeeder>>();
            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                var configuration = services.GetRequiredService<IConfiguration>();

                context.Database.EnsureCreated();
                YomichanDictionarySeeder.Seed(context, configuration, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(options => options.AllowAnyOrigin());

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}