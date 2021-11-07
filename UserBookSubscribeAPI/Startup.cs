using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using UserBookSubscribeAPI.Context;
using Microsoft.EntityFrameworkCore;
using UserBookSubscribeAPI.Manager;
using UserBookSubscribeAPI.Service.Contracts;
using UserBookSubscribeAPI.Service.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserBookSubscribeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private const string SECRET_KEY = "MyFirstJWTAPISecretKeyAuthentication";
        private IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["ConnectionStrings:usersubscribedb"];

            services.AddDbContext<UserBookSubscribeContext>(o => { o.UseSqlServer(connectionString); });
            services.AddMvc();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ISubscribeRepository, SubscribeRepository>();
            services.AddTransient<IUserBookManager, UserBookManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "jwtBearer";
                options.DefaultChallengeScheme = "jwtBearer";
            }).AddJwtBearer("jwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(60)
                };
            });

            services.AddCors(options =>
            {

                options.AddPolicy("_AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
           .AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
               {
                   Title = "User Subscribe API",
                   Description = "Book management subscribe API.",
                   Version = "v1"
               });
           });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Subscribe API1");
            })
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            })
            .UseCors();
        }
    }
}
