using Business;
using Datas;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public static class DependencyContainerApi
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusiness(configuration);
            return services;
        }
    }
}
