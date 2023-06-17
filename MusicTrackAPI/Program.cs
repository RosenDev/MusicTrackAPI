using System.Text;
using System.Text.Json.Serialization;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MusicTrackAPI.ActionFilters;
using MusicTrackAPI.Data;
using MusicTrackAPI.Services;

namespace MusicTrackAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Services.AddAppServices(builder.Configuration);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Key)
            };
        });


        builder.Services.AddControllers(options =>
        {
            options.UseDateOnlyTimeOnlyStringConverters();
            options.Filters.Add<HttpResponseExceptionFilter>();
        })
        .AddJsonOptions(options =>
        {
            options.UseDateOnlyTimeOnlyStringConverters();
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.UseDateOnlyTimeOnlyStringConverters();
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
               {
                  new OpenApiSecurityScheme
                  {
                      Reference = new OpenApiReference
                      {
                          Type=ReferenceType.SecurityScheme,
                          Id="Bearer"
                      }
                  },
                  new string[]{}
               }
            });

            opt.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
            });
        });

        builder.Services.AddCors(opts =>
        {
            opts.AddDefaultPolicy(policy =>
            {
                policy
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins("http://localhost:4200");
            });
        });

        var app = builder.Build();

        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<MusicTrackAPIDbContext>();

        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

        if(pendingMigrations.Count() > 0)
        {
            await dbContext.Database.MigrateAsync();
        }

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseCors();

        app.MapControllers();

        app.Run();
    }
}