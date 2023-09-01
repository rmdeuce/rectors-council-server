using Persistence.DB;
using Application.Common.Mappings;
using System.Reflection;
using Application.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TGMU.Utils.Auth.Jwt;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();
            builder.Services.AddMemoryCache();
            builder.Services.AddLogging();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddScheme<JwtBearerOptions, KeycloakJwtBearerHandler>(JwtBearerDefaults.AuthenticationScheme, options => { });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Авторизация в Сваггере
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IAppDBContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Services.AddCors(p => p.AddPolicy("default", corsPolicyBuilder =>
            {
                // TODO: не забыть поправить ориджин
                corsPolicyBuilder.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                try
                {
                    var context = provider.GetRequiredService<AppDBContext>();
                    DBInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    // TODO: логирование
                    Console.WriteLine(e.Message);
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("default");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}