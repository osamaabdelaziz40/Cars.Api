using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Cars.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Cars.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}