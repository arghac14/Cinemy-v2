using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Repositories;
using IMDBapp.Services;
using IMDBapp.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace IMDBapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                ));

            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "https://localhost:44303",
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz")),
                    ClockSkew = TimeSpan.Zero // remove delay of token when expire
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
