using Employee.Entities;
using Employee.Handlers;
using Employee.Helpers;
using Employee.JwtAuthRequirement;
using Employee.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"));

            services.AddAuthentication("DefaultAuth")
                .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("DefaultAuth", null);

            services.AddAuthorization(config =>
            {
                var authorizateionPolicyBuilder = new AuthorizationPolicyBuilder();
                var defaultAuthPolicy = authorizateionPolicyBuilder
                .AddRequirements(new JwtRequirement())
                .Build();
                config.DefaultPolicy = defaultAuthPolicy;
            });

            services.AddScoped<IAuthorizationHandler, JwtRequirementHandler>();

            services.AddHttpClient()
                .AddHttpContextAccessor();

            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            for (int i = 1; i < 11; i++)
            {
                context.Employees.Add(new EmployeeEntity
                {
                    Id = i,
                    Name = "Employe" + i.ToString(),
                    LastName = "Employe" + i.ToString() + " LastName",
                    Address = "Employee" + i.ToString() + " Address",
                    Department = "Employee" + i.ToString(),
                    Phone = "Employee" + i.ToString() + " Phone"
                });
            }

            context.SaveChanges();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

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
