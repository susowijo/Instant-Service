using System;
using InstantService.API.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public static class InfraDiContainerles
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfraScoped(this IServiceCollection services, IConfiguration configuration)
        {
            // context di
            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");  
            services.AddDbContextPool<InstantServiceContext>(options => 
                options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr),
                        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                            .CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds))
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()  // <-- with debugging (remove for production).
                );
            
          /* services.AddDbContext<DelenscioUserWebServiceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection5"), o =>
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds))
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()  // <-- with debugging (remove for production).
                );
           */

            services.AddRepositoryScoped();
            return services;
        }

        #endregion
    }
}