    using System.Text;
    using Autofac;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using MusicTrackAPI.Data;

    namespace MusicTrackAPI
    {
        public class Startup
        {
            private readonly IHostEnvironment environment;

            public Startup(IConfiguration configuration, IHostEnvironment environment)
            {
                this.Configuration = configuration;
                this.environment = environment;
            }

            public IConfiguration Configuration { get; private set; }

            public void ConfigureServices(IServiceCollection services)
            {

                services.AddDbContext<MusicTrackAPIDbContext>(opts =>
                opts.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));


                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Key)
                    };
                });


                services.AddControllers();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(opt =>
                {
                    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter token",
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
                });

                services.AddOptions();
            }


            public void ConfigureContainer(ContainerBuilder builder)
            {
                builder.RegisterModule(new DataLayerModule());
                builder.RegisterModule(new ServiceLayerModule());
                builder.RegisterModule(new AutomapperModule());
            }


            public void Configure(
              IApplicationBuilder app,
              ILoggerFactory loggerFactory)
            {

                if (environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthentication();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(x => x.MapControllers());
            }
        }
    }

