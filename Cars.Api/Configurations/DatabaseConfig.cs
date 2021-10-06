using System;
using Cars.Domain.Options;
using Cars.Infra.Data.Context;
//using CustomerApi.Messaging.SendAPGFundamentals.Domain.Options.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Rabbit MQ
            //services.Configure<RabbitMqConfiguration>(
            //    configuration.GetSection(nameof(RabbitMqConfiguration)));

            services.Configure<AzureServiceBusConfiguration>(
                configuration.GetSection(nameof(AzureServiceBusConfiguration)));

            //serviceClientSettingsConfig = Configuration.GetSection("AzureServiceBus");
            //services.Configure<AzureServiceBusConfiguration>(serviceClientSettingsConfig);

            //bool.TryParse(Configuration["BaseServiceSettings:UseInMemoryDatabase"], out var useInMemory);

            //if (!useInMemory)
            //{
            //    services.AddDbContext<APGFundamentalContext>(options =>
            //    {
            //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //    });
            //}
            //else
            //{
            //    services.AddDbContext<APGFundamentalContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            //}

            services.AddDbContext<CarsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<EventStoreSqlContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}