namespace WebApi;

using Core.Interfaces;
using BusinesLogic.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinesLogic.Data;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices (IServiceCollection services)
    {
        services.AddDbContext<MarketDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddTransient<IProductoRepository, ProductoRepository>();
        services.AddControllers ();
    }

    public void Configure(IApplicationBuilder App, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            App.UseDeveloperExceptionPage();
        }

        App.UseRouting();
        App.UseAuthorization();
        App.UseAuthentication();
        App.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        }); 
    }
}

