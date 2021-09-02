namespace BlazorShop.Web.Server
{
    using System.Reflection;

    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Infrastructure.Extensions;
    using Middleware;
    using BlazorShop.Data;
    using Microsoft.EntityFrameworkCore;
    using BlazorShop.Server.Services.OrdersProductServicemosso;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddApplicationServices()
                .AddApiControllers()
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                        policy.WithOrigins(new[] { "https://localhost:44337", "http://localhost:51965" })
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
                })

                 //mostafa
                 .AddScoped<IOrdersProductServicemosso, OrdersProductServicemosso>();

        //        services.AddCors(options =>
        //{
        //    options.AddDefaultPolicy(policy =>
        //        policy.WithOrigins(new[] { "http://MYDOMAIN.com", "http://localhost:38141" })
        //        .AllowAnyHeader()
        //        .AllowAnyMethod()
        //        .AllowCredentials());
        //});
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseExceptionHandling(env)
                .UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseBlazorFrameworkFiles()
                .UseStaticFiles()
                .UseRouting()
                .UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints();
        //.Initialize();
    }
}
