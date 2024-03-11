using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    public static class DependencyContainerData
    {
        public static IServiceCollection AddData(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<PMContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionMain")));

            return services;
        }
    }
}
