using codebus.apigateway.core.Business;
using codebus.apigateway.core.DbRepository;
using codebus.apigateway.core.OcelotAddin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;

namespace codebus.apigateway.portal
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<GatewayDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseMySQL(Configuration["MySql:ConnectionString"]);
            }, ServiceLifetime.Scoped);

            services.AddOcelot().AddConfigurationRepository(option =>
            {
                option.AutoUpdate = false;
                option.UpdateInterval = 10 * 1000;
            });

            services.AddScoped<IGatewayContract, GatewayServices>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(opt =>
            {
                opt.MapControllers();
            });

            app.UseGateway().Wait();
        }
    }
}
