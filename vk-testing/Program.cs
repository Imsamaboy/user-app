// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using vk_testing.Context;
using vk_testing.Extensions;
using vk_testing.Middlewares;

namespace vk_testing;

public class Program
{
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        });

        services.AddControllers();
        services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
            {
                Description = "Header for test task: Basic YWRtaW46MTIz" +
                              "<br/>Write down it in the field below and click 'Authorize'" +
                              "<br/>YWRtaW46MTIz is Base64 code of 'admin:123'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Basic"
            });

            var apiSecurityScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Basic"
                },
                Name = "Basic",
                In = ParameterLocation.Header,
            };
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                [apiSecurityScheme] = new List<string>()
            });
        });
        services.AddEndpointsApiExplorer();
        services.AddDomain();
        services.AddHelpers();
    }

    private static void ConfigureApplication(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseMiddleware<ErrorsHandlerMiddleware>();
        app.UseMiddleware<BasicAuthMiddleware>();
        app.MapControllers();
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetService<ApplicationContext>();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        ConfigureApplication(app);
        app.Run();
    }
}