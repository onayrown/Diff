using DiffedData.Data.Repositories;
using DiffedData.Domain.Interfaces.Repositories;
using DiffedData.Domain.Interfaces.Services;
using DiffedData.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiffedData.CrossCutting
{
    public static class BootStrapper 
    {
        public static void RegisterProjectServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Setup DI
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IDataServices, DataServices>();
        }
    }
}
