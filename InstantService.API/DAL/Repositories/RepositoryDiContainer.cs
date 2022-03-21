using InstantService.API.DAL.Repositories.CollectionDetails;
using InstantService.API.DAL.Repositories.Collections;
using InstantService.API.DAL.Repositories.CollectionTypes;
using InstantService.API.DAL.Repositories.Modules;
using InstantService.API.DAL.Repositories.Products;
using InstantService.API.DAL.Repositories.RolePermissions;
using InstantService.API.DAL.Repositories.Roles;
using InstantService.API.DAL.Repositories.UserRoles;
using InstantService.API.DAL.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.DAL.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public static class RepositoryDiContainer
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoryScoped(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICollectionDetailRepository, CollectionDetailRepository>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<ICollectionTypeRepository, CollectionTypeRepository>();
            services.AddTransient<IModuleRepository, ModuleRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            
            return services;
        }

        #endregion
    }
}