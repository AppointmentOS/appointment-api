using Bookeasy.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bookeasy.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbDatabaseSettings>(configuration.GetSection(nameof(MongoDbDatabaseSettings)));

            services.AddSingleton<IMongoDbDatabaseSettings>(provider =>
                provider.GetRequiredService<IOptions<MongoDbDatabaseSettings>>().Value);

            services.AddScoped<IIrisDbContext, IrisDbContext>();

            return services;
        }
    }
}
