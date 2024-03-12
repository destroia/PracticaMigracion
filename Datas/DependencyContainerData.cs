using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Datas
{
    public static class DependencyContainerData
    {
        public static IServiceCollection AddData(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<PMContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionMain")));
            services.AddScoped<IData, Data>();
            return services;
        }
    }
}
