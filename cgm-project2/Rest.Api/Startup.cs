using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DatLib = Data.Library;
using LogLib = Logic.Library;

namespace Rest.Api
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
            services.AddDbContext<DatLib.Entities.ecgbhozpContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("db")));

            //Use the following line as a template for all Repo Constructors to be injected into controllers.
            services.AddScoped<LogLib.Interfaces.IUserRepository, DatLib.Repositories.UserRepository>();
            services.AddScoped<LogLib.Interfaces.IResultRepository, DatLib.Repositories.ResultRepository>();
            services.AddScoped<LogLib.Interfaces.ICreateQuizRepository, DatLib.Repositories.CreateQuizRepository>();
            services.AddScoped<LogLib.Interfaces.IGetDataRepository, DatLib.Repositories.GetDataRepository>();
            services.AddScoped<LogLib.Interfaces.ITakeAQuizRepository, DatLib.Repositories.TakeAQuizRepository>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                        "https://cgm-project2-rest-api.azurewebsites.net")
                        .AllowAnyMethod() // not just GET and POST, but allow all methods
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });


            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-r0t9fl5u.auth0.com/";
                options.Audience = "https://cgm-project2-rest-api.azurewebsites.net";
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAngular");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}