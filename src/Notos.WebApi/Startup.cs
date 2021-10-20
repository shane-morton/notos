using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IConnection, PostgresConnection>();
            services.AddScoped<ISqlRepository, SqlRepository>();
            services.AddScoped<ISqlRepository, SqlRepository>();
            services.AddScoped<IFlightsService, FlightsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureExceptionHandler(env);

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
