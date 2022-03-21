using InstantService.API.BL.CollectionDetails;
using InstantService.API.BL.Collections;
using InstantService.API.BL.CollectionTypes;
using InstantService.API.BL.Modules;
using InstantService.API.BL.Products;
using InstantService.API.BL.RolePermissions;
using InstantService.API.BL.Roles;
using InstantService.API.BL.UserRoles;
using InstantService.API.BL.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InstantService.API.BL
{
    /// <summary>
    /// 
    /// </summary>
    public static class BlDiContainer
    {
        #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlScoped(this IServiceCollection services)
        {
            // context di
            services.AddScoped<IUserBl, UserBl>();
            services.AddScoped<IModuleBl, ModuleBl>();
            services.AddScoped<ICollectionDetailBl, CollectionDetailBl>();
            services.AddScoped<ICollectionBl, CollectionBl>();
            services.AddScoped<IProductBl, ProductBl>();
            services.AddScoped<IRolePermissionBl, RolePermissionBl>();
            services.AddScoped<IRoleBl, RoleBl>();
            services.AddScoped<IUserRoleBl, UserRoleBl>();
            services.AddScoped<ICollectionTypeBl, CollectionTypeBl>();

            return services;
        }

        #endregion
    }
}