using codebus.apigateway.core.Entities;
using codebus.apigateway.core.GatewayConfigurationRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using System;

namespace codebus.apigateway.core.DependencyInjection
{
    public static class CoreExtensions
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GatewayDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseMySQL(configuration["MySql:ConnectionString"], x => x.MigrationsAssembly("codebus.apigateway.portal"));
            }, ServiceLifetime.Scoped);
            
            services.AddOcelot().AddConfigurationRepository(option =>
            {
                option.AutoUpdate = true;
                option.UpdateInterval = 10 * 1000;
            });
        }

        public static IOcelotBuilder AddConfigurationRepository(this IOcelotBuilder builder, Action<GatewayConfiguration> options)
        {
            builder.Services.Configure(options);
            builder.Services.AddSingleton(option => option.GetRequiredService<IOptions<GatewayConfiguration>>().Value);
            builder.Services.AddHostedService<DBConfigurationPoller>();
            builder.Services.AddSingleton<IFileConfigurationRepository, MySqlFileConfigurationRepository>();
            return builder;
        }
    }
}
