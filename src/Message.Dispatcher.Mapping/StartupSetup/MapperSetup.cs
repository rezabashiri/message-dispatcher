using Message.Dispatcher.Mapping.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Application.StartupSetup
{
    public static class MapperSetup
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {

            services.AddAutoMapper(cofig => { }, AssemblyHelper.GetApplicationLayerAssembly());
            return services;
        }
    }
}
