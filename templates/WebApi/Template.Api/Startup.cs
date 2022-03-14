using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Template.ApplicationServices;
using Template.Domain;
using Template.DomainServices;
using Template.Infrastructure;

namespace Asp.Template.Api
{
    /// <summary>
    /// The main application startup point
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructs an instance
        /// </summary>
        /// <param name="configuration">A configuration object to use for app configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services">Service container that houses services for dependency injection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomain();
            services.AddDomainServices();
            services.AddApplicationServices();
            services.AddInfrastructure();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asp.Template.Api", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app">An application bulder instance for adding and configuring middleware</param>
        /// <param name="env">Environment information the app is running within</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
