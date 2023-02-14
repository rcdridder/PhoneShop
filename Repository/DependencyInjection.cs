using Business;
using Business.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>()
                .AddScoped<IPhoneRepository, PhoneRepository>();

            services.AddDbContext<PhoneShopDataContext>();
            return services;
        }
    }
}
