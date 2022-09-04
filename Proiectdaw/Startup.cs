using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Proiectdaw.Data;
using Proiectdaw.Entities;
using Proiectdaw.Models.Constants;
using Proiectdaw.Repositories;
using Proiectdaw.Repositories.CoachRepository;
using Proiectdaw.Repositories.CompetitionRepository;
using Proiectdaw.Repositories.GenericRepository;
using Proiectdaw.Repositories.PlayerRepository;
using Proiectdaw.Repositories.TeamRepository;
using Proiectdaw.Seed;
using Proiectdaw.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiectdaw
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proiectdaw", Version = "v1" });
            });

            services.AddDbContext<Context>(options => options.UseSqlServer("Data Source=DESKTOP-NOA3EKN;Initial Catalog=ProiectdawDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoleType.Admin, policy => policy.RequireRole(UserRoleType.Admin));
                options.AddPolicy(UserRoleType.User, policy => policy.RequireRole(UserRoleType.User));
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth")),
                        ValidateIssuerSigningKey = true
                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnTokenValidated = Helpers.SessionTokenValidator.ValidateSessionToken
                    };
                }
                );

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddScoped<ITeamRepository, TeamRepository>();
          

            services.AddScoped<ICoachRepository, CoachRepository>();
           

            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            

           // services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
           

            services.AddScoped<SeedDb>();

}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,SeedDb seed, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proiectdaw v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            try
            {
                seed.SeedRoles().Wait();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
