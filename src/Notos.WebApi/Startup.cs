using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Notos.Database.Interfaces;
using Notos.Database.Postgres;
using Notos.Database.Repositories;
using Notos.Service;
using Notos.Service.Interfaces;
using Notos.WebApi.Extensions;

namespace Notos.WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Notos Api",
                    Version = "v1",
                    Description = "A free-flight pilots log book",
                    Contact = new OpenApiContact
                    {
                        Name = "Shane Morton",
                        Email = "thathanggliderguy@gmail.com"
                    }
                });
            });

            services.AddScoped<IConnection, PostgresConnection>();
            services.AddScoped<ISqlRepository, SqlRepository>();
            services.AddScoped<IFlightsRepository, FlightsRepository>();
            services.AddScoped<IFlightsService, FlightsService>();

            ConfigureDatabaseSettings(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            logger.LogInformation("Configuring Middleware");

            app.ConfigureExceptionHandler(env, logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Notos Api");
                c.RoutePrefix = string.Empty;
            });

            logger.LogInformation(Configuration.GetSection("Postgres")["HostName"]);
        }

        public void ConfigureDatabaseSettings(IServiceCollection services)
        {
            services.Configure<PostgresSettings>(options =>
                Configuration.GetSection("Postgres").Bind(options));
        }
    }
}
