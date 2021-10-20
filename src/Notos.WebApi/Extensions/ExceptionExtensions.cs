using System.Net;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

using Notos.Service.Exceptions;

namespace Notos.WebApi.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {

                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            switch (ex.Error)
                            {
                                case NotFoundException notFoundException:
                                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                    break;
                                default:
                                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                    break;
                            }

                            await context.Response.WriteAsync(ex.Error.Message);
                        }
                    });
                });
            }
        }
    }
}
